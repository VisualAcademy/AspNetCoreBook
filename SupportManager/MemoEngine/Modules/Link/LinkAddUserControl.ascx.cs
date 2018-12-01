using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Common;
using MemoEngine.Models;

namespace MemoEngine.Modules.Link
{
    public partial class LinkAddUserControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            LinkModel link = new LinkModel();

            link.Title = txtTitle.Value;
            link.Url = txtUrl.Value;
            link.ViewOrder = Convert.ToInt32(txtViewOrder.Value);
            link.Description = txtDescription.Value;

            var repo = new LinkRepository();

            int result = repo.AddLink(link);

            if (result > 0)
            {
                lblError.Text = "저장 완료";
            }
            else
            {
                lblError.Text = "저장되지 않음";
            }
        }
    }
}