using System;
using System.Configuration;

namespace DevConfiguration
{
    public partial class FrmAppSettings : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string title = $"[{ConfigurationManager.AppSettings["SITE_URL"]}] 새로운 비밀번호 발급/New password is created";

            string message = "";

            message += $"안녕하세요. {ConfigurationManager.AppSettings["SITE_NAME"]}입니다." + "\r\n";
            message += $"Hello. This is {ConfigurationManager.AppSettings["SITE_NAME"]}." + "\r\n";
            message += "\r\n";

            message += "요청하신 임시 비밀번호는 다음과 같습니다." + "\r\n";
            message += "The temporary password you have requested is listed below." + "\r\n";
            message += "\r\n";
            
            txtContent.Text = title + "\r\n" + message; 
        }
    }
}
