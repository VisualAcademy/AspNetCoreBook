using System;
using System.Web.UI;

namespace MemoEngine.Modules.SupportManager
{
    public partial class SupportRegistrationUserControl : System.Web.UI.UserControl
    {
        public string BoardName { get; set; }
        public int BoardNum { get; set; }
        public string Username { get; set; } = "아이디";

        private SupportRegistrationRepository _respository;

        public SupportRegistrationUserControl()
        {
            _respository = new SupportRegistrationRepository();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            BoardName = Request.QueryString["BoardName"];
            BoardNum = Convert.ToInt32(Request.QueryString["Num"]);

            btnRegistration.NavigateUrl =
                "/Modules/SupportManager/SupportFormPage.aspx"
                + $"?BoardName={BoardName}&Num={BoardNum}";

            btnSupportManager.NavigateUrl =
                "/Modules/SupportManager/SupportSettingAdminPage.aspx"
                + $"?BoardName={BoardName}&Num={BoardNum}";

            if (!Page.IsPostBack)
            {
                DisplayData(); // 등록한 서포트 리스트 출력
                CheckFinishedSupportRegistration(); // 등록 마감 여부 확인
                CheckRegistredUser(); // 등록한 사용자인지 확인

                CheckIsClosedSupport(); // 완전 종료된 이벤트 여부 확인

                CheckIsEventTime(); // EventDate 컬럼의 시간이 지나면 true
            }
        }

        private void CheckIsEventTime()
        {
            var settingRepo = new SupportSettingRepository();
            if (settingRepo.IsEventTime(BoardName, BoardNum))
            {
                btnRegistration.Enabled = true;
                //btnRegistration.Text = "신청하기";
            }
            else
            {
                btnRegistration.Enabled = false;
                btnRegistration.Text = "신청하기(등록 전입니다.)";
            }
        }

        private void CheckIsClosedSupport()
        {
            var repo = new SupportSettingRepository();
            var model = repo.GetById(BoardName, BoardNum);
            if (model != null)
            {
                if (model.IsClosed)
                {
                    divUserView.Visible = false;
                    divClosedMessage.Visible = !divUserView.Visible;
                }
                else
                {
                    divUserView.Visible = true;
                    divClosedMessage.Visible = !divUserView.Visible;
                }
                pnlNotYet.Visible = false; // 세부 설정 안내 메시지 숨기기 
            }
            else
            {
                // 이벤트 설정이 완료되지 않으면 사용자 패널 숨기기 
                divUserView.Visible = false;
                divClosedMessage.Visible = false;
                pnlNotYet.Visible = true; // 세부 설정 안내 메시지 보이기
            }
        }

        private void CheckRegistredUser()
        {
            bool result = 
                _respository.IsRegisteredUser(BoardName, BoardNum, Username);
            if (result)
            {
                btnRemoveRegistration.Visible = true;
                btnRegistration.Text = "신청 내용 수정";
            }
            else
            {
                btnRemoveRegistration.Visible = false;
                btnRegistration.Text = "신청하기";
            }
        }

        private void CheckFinishedSupportRegistration()
        {
            if (_respository.IsFinishedSupportRegistration(BoardName, BoardNum))
            {
                btnRegistration.Text = "마감되었습니다.";
                btnRegistration.Enabled = false; 
            }
            else
            {
                btnRegistration.Text = "신청하기";
                btnRegistration.Enabled = true;
            }
        }

        private void DisplayData()
        {
            var model = _respository.GetAll(BoardName, BoardNum);
            ctlSupportList.DataSource = model; 
            ctlSupportList.DataBind();
        }

        protected void btnRemoveRegistration_Click(object sender, EventArgs e)
        {
            _respository.RemoveSupportRegistration(BoardName, BoardNum, Username);
            Response.Redirect(Request.RawUrl);
        }
    }
}