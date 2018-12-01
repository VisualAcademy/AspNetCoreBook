using System;

namespace DevStandardControl
{
    public partial class FrmDropDownListRedirect : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lstBoard_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = this.lstBoard.SelectedValue;
            Response.Redirect($"/BoardList.aspx?BoardName={selected}"); 
        }
    }
}
