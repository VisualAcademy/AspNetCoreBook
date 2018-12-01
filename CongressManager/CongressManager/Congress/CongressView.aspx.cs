using All;
using System;
using System.Web.UI;

namespace CongressManager.Congress
{
    public partial class CongressView : System.Web.UI.Page
    {
        private string _Id; // 앞(리스트)에서 넘겨져 온 번호 저장

        protected void Page_Load(object sender, EventArgs e)
        {
            _Id = Request.QueryString["Id"];

            lnkDelete.NavigateUrl = "CongressDelete.aspx?Id=" + _Id;
            lnkModify.NavigateUrl = "CongressModify.aspx?Id=" + _Id;
            lnkReply.NavigateUrl = "CongressReply.aspx?Id="   + _Id;
            
            if (_Id == null)
            {
                Response.Redirect("./CongressList.aspx");
            }

            if (!Page.IsPostBack)
            {
                // 넘겨져 온 번호에 해당하는 글만 읽어서 각 레이블에 출력
                DisplayData();
            }
        }

        private void DisplayData()
        {
            // 넘겨온 Id 값에 해당하는 레코드 하나 읽어서 Note 클래스에 바인딩
            var vm = (new CongressRepository()).GetNoteById(Convert.ToInt32(_Id));

            lblNum.Text = _Id; // 번호
            lblName.Text = vm.Name; // 이름
            lblEmail.Text = String.Format("<a href=\"mailto:{0}\">{0}</a>", vm.Email);
            lblTitle.Text = vm.Title;
            string content = vm.Content;

            // 인코딩 방식에 따른 데이터 출력
            string strEncoding = vm.Encoding;
            if (strEncoding == "Text") // Text: 소스 그대로 표현
            {
                lblContent.Text = Dul.HtmlUtility.EncodeWithTabAndSpace(content);
            }
            else if (strEncoding == "Mixed") // Mixed: 엔터처리만
            {
                lblContent.Text = content.Replace("\r\n", "<br />");
            }
            else // HTML: HTML 형식으로 출력
            {
                lblContent.Text = content; // 변환없음
            }

            lblReadCount.Text = vm.ReadCount.ToString();
            lblHomepage.Text = String.Format("<a href=\"{0}\" target=\"_blank\">{0}</a>", vm.Homepage);
            lblPostDate.Text = vm.PostDate.ToString();
            lblPostIp.Text = vm.PostIp;
            if (vm.FileName.Length > 1)
            {
                lblFile.Text = String.Format(
                    "<a href='./BoardDown.aspx?Id={0}'>" + "{1}{2} / 전송수: {3}</a>",
                    vm.Id, "<img src=\"/images/ext/ext_zip.gif\" border=\"0\">",
                    vm.FileName, vm.DownCount);
                if (Dul.BoardLibrary.IsPhoto(vm.FileName))
                {
                    ltrImage.Text = "<img src=\'ImageDown.aspx?FileName=" + $"{Server.UrlEncode(vm.FileName)}\'>";
                }
            }
            else
            {
                lblFile.Text = "(업로드된 파일이 없습니다.)";
            }
        }
    }
}
