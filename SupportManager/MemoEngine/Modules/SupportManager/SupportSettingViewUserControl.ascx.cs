using System;

namespace MemoEngine.Modules.SupportManager
{
    public partial class SupportSettingViewUserControl : System.Web.UI.UserControl
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

        private SupportRegistrationRepository _respository;

        public SupportSettingViewUserControl()
        {
            _respository = new SupportRegistrationRepository();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            hdnBoardName.Value = Request["BoardName"];
            hdnNum.Value = Request["Num"];

            BoardName = Request.QueryString["BoardName"];
            BoardNum = Convert.ToInt32(Request.QueryString["Num"]);

            // 현재 이벤트 관련 게시판 상세 보기 페이지로 이동 
            lnkBoardView.NavigateUrl = 
                $"/BoardView.aspx?BoardName={BoardName}&Num={BoardNum}";

            if (!Page.IsPostBack)
            {
                DisplayData(); // 등록한 서포트 리스트 출력
            }
        }

        private void DisplayData()
        {
            var model = _respository.GetAll(BoardName, BoardNum);
            ctlSupportList.DataSource = model;
            ctlSupportList.DataBind();
        }
    }
}
