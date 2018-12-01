using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MemoEngine
{
    public partial class Site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // 모든 페이지의 기본 타이틀 지정
            //Page.Title = System.Configuration.ConfigurationManager.AppSettings["SITE_NAME"];
        }
    }
}