using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MemoEngine.Repositories;

namespace MemoEngine.Tests
{
    public partial class FrmEventFirstAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                EventFirstRepository repo = new EventFirstRepository();
                this.ctlEventList.DataSource = repo.GetEventList();
                this.ctlEventList.DataBind(); 
            }
        }
    }
}