using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MemoEngine.Modules.SupportManager
{
    public partial class SupportRegistrationFormUserControl : System.Web.UI.UserControl
    {
        /// <summary>
        /// 게시판 이름(Alias)
        /// </summary>
        public string BoardName { get; set; }
        /// <summary>
        /// 게시판 글 고유 번호
        /// </summary>
        public int BoardNum { get; set; }
        /// <summary>
        /// 현재 접속 중인 사용자 아이디 
        /// </summary>
        public string Username { get; set; }

        private SupportRegistrationRepository _repository;
        public SupportRegistrationFormUserControl()
        {
            _repository = new SupportRegistrationRepository();
            Username = "아이디"; // TODO: 여기는 변경할 것 
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            hdnBoardName.Value = Request["BoardName"];
            hdnNum.Value = Request["Num"];

            BoardName = Request.QueryString["BoardName"];
            BoardNum = Convert.ToInt32(Request.QueryString["Num"]);

            // 게시판 상세보기(BoardView)로 이동
            btnGoToBoardView.NavigateUrl =
                $"~/BoardView.aspx?BoardName={BoardName}&Num={BoardNum}";

            if (!Page.IsPostBack)
            {
                SettingDateTimeField(); // 기본 날짜값 설정
                DisplayData();
            }
        }

        private void SettingDateTimeField()
        {
            // 샘플로 날짜값을 다음날로 설정: 시간 표시는 생략 
            txtDateTime.Text = DateTime.Now.AddDays(1).ToShortDateString();
        }

        private void DisplayData()
        {
            // 기존에 저장한 데이터가 있으면 각각의 컨트롤에 바인딩
            var model = _repository.GetById(BoardName, BoardNum, Username);

            if (model != null)
            {
                txtName.Text = model.Name;
                txtMobile.Text = model.Mobile;
                txtCompany.Text = model.Company;
                txtHomepage.Text = model.Homepage;
                txtDateTime.Text = model.SupportDate;
                txtRecipient.Text = model.Recipient;
                txtProduct.Text = model.Product;

                btnSave.Visible = false; // 저장 버튼 숨기기
                btnModify.Visible = true; // 수정 버튼 보이기
                btnDelete.Visible = true; // 취소 버튼 보이기
                divAgreement.Visible = false; // 약관 숨기기
            }
            else
            {
                btnSave.Visible = true;
                btnModify.Visible = false;
                btnDelete.Visible = false;
                divAgreement.Visible = true; // 약관 보이기
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            // sender 개체를 버튼으로 변환 후 현재 클릭 이벤트를 발생시킨 ID 가져오기
            Button btn = sender as Button;

            SupportRegistration model = new SupportRegistration();
            model.SupportSettingId = -1;
            model.BoardName = hdnBoardName.Value;
            model.BoardNum = Convert.ToInt32(hdnNum.Value);
            model.BoardTitle = "제목";
            model.CreationDate = DateTime.Now;

            model.UserId = Convert.ToInt32(-1);
            model.Username = "아이디";
            model.NickName = "닉네임";

            model.Name = txtName.Text;
            model.Mobile = txtMobile.Text;
            model.Company = txtCompany.Text;
            model.Homepage = txtHomepage.Text;
            model.SupportDate = txtDateTime.Text;
            model.Recipient = txtRecipient.Text;
            model.Product = txtProduct.Text;

            // 서버측 유효성 검사 진행 
            if (model.Name == "")
            {
                Page.ClientScript.RegisterClientScriptBlock(
                    this.GetType(),
                    "NoValidate",
                    "<script>이름을 입력하세요.</script>");
            }
            else
            {
                var repository = new SupportRegistrationRepository();

                // 어떤 버튼이 클릭되었는지 확인 후 해당 기능(저장, 수정, 삭제) 수행
                if (btn.ID == "btnSave")
                {
                    // 체크박스 2개와 등록자 서명(이름) 기입하면 저장 가능
                    if (chkNecessary.Checked 
                        && chkOption.Checked 
                        && txtAgreementName.Text != "")
                    {
                        // 입력
                        repository.Add(model);
                    }
                    else
                    {
                        lblError.Visible = true;
                        return; 
                    }
                }
                else if (btn.ID == "btnModify")
                {
                    // 수정
                    repository.Update(model);
                }
                else if (btn.ID == "btnDelete")
                {
                    repository.Remove(BoardName, BoardNum, Username);
                }

                Response.Redirect(Request.RawUrl);
            }
        }
    }
}