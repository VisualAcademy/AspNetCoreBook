using MemoEngine.Models;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MemoEngine.Modules.Link
{
    public partial class LinkListUserControl : System.Web.UI.UserControl
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
            //this.ctlLinkList.DataSource = (new DatabaseProviderFactory()).Create("ConnectionString").ExecuteDataSet(CommandType.Text, "Select * From Links Order By Id Asc");
            //this.ctlLinkList.DataBind(); 
            this.ctlLinkList.DataSource = (new LinkRepository()).GetLinks();
            this.ctlLinkList.DataBind();
        }
    }
}