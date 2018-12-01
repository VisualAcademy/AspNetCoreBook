using Basic.Models;
using System;

namespace Basic.Basic
{
    public partial class List : System.Web.UI.Page
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
            var repository = new BasicRepository();

            ctlBasicList.DataSource = repository.GetAll();
            ctlBasicList.DataBind();
        }
    }
}
