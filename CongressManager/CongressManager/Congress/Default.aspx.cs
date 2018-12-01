using System;

namespace CongressManager.Congress
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // 리스트 페이지로 이동
            Response.Redirect("~/Congress/CongressList.aspx");
        }
    }
}