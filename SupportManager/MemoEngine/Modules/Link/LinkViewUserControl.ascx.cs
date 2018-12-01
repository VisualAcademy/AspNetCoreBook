using MemoEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MemoEngine.Modules.Link
{
    public partial class LinkViewUserControl : System.Web.UI.UserControl
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
            var repo = new LinkRepository();

            var link = repo.GetLink(Convert.ToInt32(Request["Id"]));

            if (link != null)
            {
                this.txtTitle.Value = link.Title;
                this.txtUrl.Value = link.Url;
                this.txtViewOrder.Value = link.ViewOrder.ToString();
                this.txtDescription.Value = link.Description; 
            }
            else
            {
                lblError.ForeColor = System.Drawing.Color.Red; 
                lblError.Text = "해당되는 데이터가 없습니다.";
            }
        }

        protected void btnModify_Click(object sender, EventArgs e)
        {
            LinkModel link = new LinkModel();

            link.Title          = this.txtTitle.Value;         
            link.Url            = this.txtUrl.Value;           
            link.ViewOrder      = Convert.ToInt32(this.txtViewOrder.Value);
            link.Description    = this.txtDescription.Value;

            link.Id = Convert.ToInt32(Request["Id"]);

            var linkRepo = new LinkRepository();
            linkRepo.UpdateLink(link);

            this.lblError.Text = "수정되었습니다.";
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            int result = (new LinkRepository()).DeleteLink(Convert.ToInt32(Request["Id"]));
            if (result > 0)
            {
                //lblError.Text = "삭제되었습니다.";
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "goList", "<script>window.alert('삭제되었습니다.');location.href='LinkList.aspx';</script>");
            }
            else
            {
                lblError.Text = "삭제되지 않았습니다.";
            }
        }

    }
}