using SiteSetting.Models.SiteSettingModule;
using SiteSetting.Repositories.SiteSettingModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SiteSetting.Controls.SiteSettingModule
{
    public partial class SiteSettingAddUserControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            // 모델 엔터티 채우기
            SiteSettingModel setting = new SiteSettingModel();
            setting.ShowMenu1 = this.chkShowMenu1.Checked; 

            // 리파지터리 개체에 전달
            SiteSettingRepository repo = new SiteSettingRepository();
            setting = repo.AddSiteSettting(setting);

            // 레이블에 Id 출력
            lblDisplay.Text = String.Format("{0}번 레코드가 저장됨", setting.Id); 
        }
    }
}