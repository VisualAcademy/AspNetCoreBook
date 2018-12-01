using SiteSetting.Repositories.SiteSettingModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SiteSetting.Controls.SiteSettingModule
{
    public partial class SiteMenuUserControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DisplayData();
            }
        }

        private void DisplayData()
        {
            var repo = new SiteSettingRepository();

            this.divSiteMenu1.Visible = repo.IsShowMenu1(); // 참이면 보이기
        }
    }
}