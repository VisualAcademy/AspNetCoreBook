using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MemoEngine.Modules.DivisionModule.Controls
{
    public partial class DivisionManagerUserControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ctlDivisionAdd_ItemInserted(object sender, FormViewInsertedEventArgs e)
        {
            // 현재 페이지 새로 로드
            Response.Redirect(Request.RawUrl);
        }
    }
}