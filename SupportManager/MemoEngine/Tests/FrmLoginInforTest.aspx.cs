using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MemoEngine.Tests
{
    public partial class FrmLoginInforTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write(Session["UID"]);
            Response.Write(Session["UserID"]);
            Response.Write(Session["UserName"]);
            Response.Write(Session["UserEmail"]);
            Response.Write(Session["LoginDate"]);
            Response.Write(Session["VisitedCount"]);
        }
    }
}