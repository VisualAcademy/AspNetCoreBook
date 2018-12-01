using MemoEngine.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MemoEngine.Modules.DivisionModule.Controls
{
    public partial class DivisionListUserControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DisplayDivisions();
            }
        }

        private void DisplayDivisions()
        {
            DivisionRepository divisions = new DivisionRepository();
            lstDivisionsUserControl.DataSource = divisions.GetDivisions();
            lstDivisionsUserControl.DataTextField = "DivisionName";
            lstDivisionsUserControl.DataValueField = "DivisionId";
            lstDivisionsUserControl.DataBind();
        }
    }
}