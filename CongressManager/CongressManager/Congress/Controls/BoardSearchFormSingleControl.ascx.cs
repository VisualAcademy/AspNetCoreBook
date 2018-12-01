using System;

namespace CongressManager.Congress.Controls
{
    public partial class BoardSearchFormSingleControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Empty 
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string strQuery = $"{Request.ServerVariables["SCRIPT_NAME"]}?SearchField={SearchField.SelectedItem.Value}&SearchQuery={SearchQuery.Text}";
            Response.Redirect(strQuery);
        }
    }
}
