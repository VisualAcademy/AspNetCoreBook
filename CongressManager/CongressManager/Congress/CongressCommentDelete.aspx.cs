using All;
using System;

namespace CongressManager.Congress
{
    public partial class CongressCommentDelete : System.Web.UI.Page
    {
        public int ArticleId { get; set; } // 게시판 글 번호
        public int Id { get; set; } // 댓글 번호

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["ArticleId"] != null && Request.QueryString["Id"] != null)
            {
                ArticleId = Convert.ToInt32(Request["ArticleId"]);
                Id = Convert.ToInt32(Request["Id"]);
            }
            else
            {
                Response.End();
            }
        }

        protected void btnCommentDelete_Click(object sender, EventArgs e)
        {
            var repo = new CongressCommentRespository();
            if (repo.GetCountBy(ArticleId, Id, txtPassword.Text) > 0)
            {
                repo.DeleteComment(ArticleId, Id, txtPassword.Text);
                Response.Redirect($"CongressView.aspx?Id={ArticleId}");
            }
            else
            {
                lblError.Text = "암호가 틀립니다. 다시 입력해주세요.";
            }
        }
    }
}
