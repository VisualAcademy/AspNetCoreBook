using Reply.Bsl;
using Reply.Common;
using Reply.Entity;
using System;
using System.Web.UI;

namespace MemoEngine.Reply
{
    public partial class View : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(Request["Num"]))
            {
                Response.Write("잘못된 요청");
                Response.End();
            }
            else
            {
                if (!Page.IsPostBack)
                {
                    DisplayData();
                }
            }
        }

        private void DisplayData()
        {
            // 메서드 실행 후 그 결과값을 ReplyEntity 엔터티 개체에 담기
            ReplyEntity re = (new ReplyBiz()).SelectReplyByNum(Convert.ToInt32(Request["Num"]));
            // 각각의 컨트롤에 바인딩
            lblNum.Text = Request["Num"];
            lblTitle.Text = re.Title;
            lblName.Text = re.Name;
            lblEmail.Text = re.Email;
            lblHomepage.Text = re.Homepage;
            lblPostDate.Text = re.PostDate.ToString();

            // 수정되었을 때에만, 해당 날짜 기록
            if (re.ModifyDate != DateTime.MinValue)
            {
                lblModifyDate.Text = re.ModifyDate.ToString();
            }

            lblReadCount.Text = re.ReadCount.ToString();
            lblPostIP.Text = re.PostIP;

            #region 인코딩 방식에 따른 컨텐츠 출력
            lblContent.Text =
                BoardUtil.ConvertContentByEncoding(re.Content, re.Encoding);
            //if (re.Encoding == "Text") // 태그 실행 방지/소스 그대로
            //{
            //    lblContent.Text =
            //        re.Content.Replace("&", "&amp;").Replace(
            //                "<", "&lt;").Replace(">", "&gt;").Replace(
            //                        "\r\n", "<br />").Replace("\t", "&nbsp;&nbsp;&nbsp;&nbsp;");
            //}
            //else if (re.Encoding == "Mixed") // 태그 실행
            //{
            //    lblContent.Text = re.Content.Replace("\r\n", "<br />");
            //}
            //else // HTML로 표시
            //{
            //    lblContent.Text = re.Content;
            //}
            #endregion
        }

        protected void btnReply_Click(object sender, EventArgs e)
        {
            // Mode=Reply로 Write.aspx 페이지로 넘어가면, 답변 로직 처리
            Response.Redirect("Write.aspx?Mode=Reply&Num=" + Request["Num"]);
        }
    }
}