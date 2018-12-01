using MemoEngine.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MemoEngine.Tests
{
    public partial class FrmGetDivisions : System.Web.UI.Page
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
            lstDivisions.DataSource = divisions.GetDivisions();
            lstDivisions.DataTextField = "DivisionName";
            lstDivisions.DataValueField = "DivisionId";
            lstDivisions.DataBind();
        }

        protected void btnSelectData_Click(object sender, EventArgs e)
        {
            lblDisplay.Text = Request.Form["DivisionListUserControl$lstDivisionsUserControl"]; 
        }
    }
}