using System;

namespace MemoEngine.Modules.SupportManager
{
    public partial class SupportRegistrationViewUserControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lnkGoBack.NavigateUrl =
                $"SupportSettingView.aspx?BoardName={Request["BoardName"]}&Num={Request["Num"]}";
        }
    }
}
