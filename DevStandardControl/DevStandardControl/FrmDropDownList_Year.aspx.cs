using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DevStandardControl
{
    public partial class FrmDropDownList_Year : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindYear();
                BindDropDownList();
            }
        }

        private void BindYear()
        {
            for (int i = DateTime.Now.Year; i > DateTime.Now.Year - 5; i--)
            {
                ddlYear.Items.Add(
                    new ListItem() { Text = $"{i}년", Value = i.ToString() });
            }
        }

        private void BindDropDownList()
        {
            for (int i = 1; i <= 12; i++)
            {
                ListItem li = new ListItem() {
                    Text = $"{i}월", Value = i.ToString() };
                lstMonth.Items.Add(li);
            }
        }
    }
}
