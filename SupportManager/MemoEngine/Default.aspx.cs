using System;
using System.Web.UI;

namespace MemoEngine
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "HOME - MemoEngine CMS Solution";
            strSITE_NAME.Text = System.Configuration
                .ConfigurationManager.AppSettings["SITE_NAME"]; 
        }
    }
}
