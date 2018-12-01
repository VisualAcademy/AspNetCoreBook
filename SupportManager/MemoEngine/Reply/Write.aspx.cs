using Reply.Bsl;
using Reply.Entity;
using System;
using System.Web.UI;

namespace MemoEngine.Reply
{
    public partial class Write : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Mode=Reply 식으로 Mode값이 널/빈 값이 아니라면, 답변하기 로직 적용
            if (!String.IsNullOrEmpty(Request["Mode"]))
            {
                ltrTitle.Text = "답변달기";
                btnWrite.Text = "글 답변";
                if (!Page.IsPostBack)
                {
                    DisplayData();
                }
            }
        }

        private void DisplayData()
        {
            // 부모글의 제목과 내용을 텍스트박스에 바인딩
            ReplyEntity re = (new ReplyBiz()).SelectReplyByNum(Convert.ToInt32(Request["Num"]));

            this.txtTitle.Text = "Re : " + re.Title; // 부모글의 Re : 붙여서 출력
            this.txtContent.Text =
                "\r\n\r\n--------------------\r\n>" +
                re.Content.Replace("\r\n", "\r\n>")
                + "\r\n--------------------\r\n";
        }

        protected void btnWrite_Click(object sender, EventArgs e)
        {
            ReplyEntity re = new ReplyEntity();

            re.Name = txtName.Text;
            re.Email = txtEmail.Text;
            re.Homepage = txtHomepage.Text;
            re.Title = txtTitle.Text;
            re.PostIP = Request.UserHostAddress;
            re.Content = txtContent.Text;
            re.Encoding = lstEncoding.SelectedValue;
            re.Password = txtPassword.Text;

            if (!String.IsNullOrEmpty(Request["Mode"]) && Request["Mode"].ToLower() == "reply")
            {
                // 답변 로직 처리 : 두번째 매개변수가 부모글의 번호(ParentNUm)로 저장
                (new ReplyBiz()).InsertReply(re, Convert.ToInt32(Request["Num"]));
            }
            else
            {
                // 저장 로직 처리
                ReplyBiz rb = new ReplyBiz();
                rb.InsertReply(re);
            }

            // 리스트로 이동
            string strJs = @"
            <script>alert('입력되었습니다.'); location.href='List.aspx';</script>
        ";
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "goList", strJs);
        }
    }
}