using MemoEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MemoEngine.Market.Test
{
    public partial class ProductListTest : System.Web.UI.Page
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
            ProductRepository repo = new ProductRepository();
            GridView1.DataSource = repo.GetAllProducts();
            GridView1.DataBind(); 
        }
    }
}