using System;

namespace MemoEngine.Modules.SupportManager
{
    public partial class SupportSettingAdminUserControl : System.Web.UI.UserControl
    {
        public string BoardName { get; set; }
        public int BoardNum { get; set; }
        public string Username { get; set; }

        private SupportSettingRepository _repository;
        public SupportSettingAdminUserControl()
        {
            _repository = new SupportSettingRepository();
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

            // SupportRegistrationListExcel.aspx
            btnSupportListExcel.NavigateUrl =
                $"~/Modules/SupportManager/SupportRegistrationListExcel.aspx" 
                + $"?BoardName={BoardName}&Num={BoardNum}";

            if (!Page.IsPostBack)
            {
                SettingDateTimeField(); // 기본값 설정을 먼저 
                DisplayData();
            }
        }

        private void SettingDateTimeField()
        {
            // 샘플 날짜 값 등록하기
            txtStartDate.Text = DateTime.Now.ToString();
            txtEventDate.Text = DateTime.Now.AddDays(1).ToString();
            txtEndDate.Text = DateTime.Now.AddDays(7).ToString(); 
        }

        private void DisplayData()
        {
            // 기존에 저장한 데이터가 있으면 각각의 컨트롤에 바인딩
            var model = _repository.GetById(BoardName, BoardNum);

            if (model != null)
            {
                chkIsClosed.Checked = model.IsClosed; 
                txtStartDate.Text = model.StartDate.ToShortDateString();
                txtEventDate.Text = model.EventDate.ToShortDateString();
                txtEndDate.Text = model.EndDate.ToShortDateString();
                txtMaxRegistrationCount.Text = model.MaxCount.ToString();
                txtRemarks.Text = model.Remarks;

                // 기존 저장된 데이터가 있으면
                btnSave.Text = "설정 수정";
            }
            else
            {
                btnSave.Text = "설정 저장";
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            // 폼 개체를 모델 개체에 담기 
            SupportSetting model = new SupportSetting();
            
            model.Remarks = txtRemarks.Text;
            model.CreationDate = DateTimeOffset.Now;
            model.BoardName = BoardName;
            model.BoardNum = BoardNum;
            model.BoardTitle = "";
            model.BoardContent = "";
            model.StartDate = Convert.ToDateTime(txtStartDate.Text);
            model.EventDate = Convert.ToDateTime(txtEventDate.Text);
            model.EndDate = Convert.ToDateTime(txtEndDate.Text);
            model.MaxCount = Convert.ToInt32(txtMaxRegistrationCount.Text);

            // 이벤트 등록 완전 종료
            model.IsClosed = chkIsClosed.Checked; 
            if (model.MaxCount == 0)
            {
                model.IsClosed = true; 
            }
            
            // 저장 또는 업데이트
            _repository.AddOrUpdateSupportSetting(model);

            Response.Redirect(Request.RawUrl); // 현재 페이지 다시 요청
        }

        protected void btnRegistrationExcel_Click(object sender, EventArgs e)
        {
            // 서포트 리스트 엑셀 다운로드
            var registationRepo = new SupportRegistrationRepository();

            // 현재 게시판의 번호에 해당하는 등록자 리스트 가져오기
            var registrations = registationRepo.GetAll(BoardName, BoardNum);

            for (int i = 0; i < registrations.Count; i++)
            {
                registrations[i].Product =
                    registrations[i].Product
                        .Replace("\r\n", ",").Replace("\n", ",");
            }

            // 엑셀로 다운로드
            ExcelDownUtility.ExcelDownloadWithTabSeparatedValues(
                registrations, Response.Output);
        }
    }
}
