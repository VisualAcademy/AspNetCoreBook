using All;
using Hawaso.Standard;
using System;
using System.Web.UI;

namespace CongressManager.Congress.Controls
{
    public partial class BoardCommentControl : System.Web.UI.UserControl
    {
        private CongressCommentRespository _repository;

        public BoardCommentControl()
        {
            _repository = new CongressCommentRespository();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                // 데이터 출력(현재 게시글의 번호(Id)에 해당하는 댓글 리스트)
                ctlCommentList.DataSource = _repository.GetComments(Convert.ToInt32(Request["Id"]));
                ctlCommentList.DataBind();
            }
        }

        protected void btnWriteComment_Click(object sender, EventArgs e)
        {
            ArticleCommentBase comment = new ArticleCommentBase();
            comment.ArticleId = Convert.ToInt32(Request["Id"]); // 부모글
            comment.Name = txtName.Text; // 이름
            comment.Password = txtPassword.Text; // 암호
            comment.Opinion = txtOpinion.Text; // 댓글

            // 데이터 입력
            _repository.AddComment(comment);

            Response.Redirect($"{Request.ServerVariables["SCRIPT_NAME"]}?Id={Request["Id"]}");
        }
    }
}