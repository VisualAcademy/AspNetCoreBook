using MemoEngine.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MemoEngine.Controls.BadWord
{
    public partial class ListBadWordUserControl : System.Web.UI.UserControl
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
            var repo = new BadWordRepository();

            this.ctlBadWordList.DataSource = repo.GetBadWords();
            this.ctlBadWordList.DataBind(); 
        }
    }
}