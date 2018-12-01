using MemoEngine.Models;
using MemoEngine.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MemoEngine.Controls.BadWord
{
    public partial class GetBadWordUserControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ReadData();
            }
        }

        private void ReadData()
        {
            int id = Convert.ToInt32(Request["Id"]);

            var model = new BadWordModel();
            var repo = new BadWordRepository();            
            model = repo.Find(id);

            if (model != null)
            {
                txtWord.Text = model.Word;  
            }
            else
            {
                string strJs = "<script>window.alert('데이터가 없습니다.');</script>";
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "noData", strJs);
            }
        }

        protected void btnModify_Click(object sender, EventArgs e)
        {
            BadWordModel model = new BadWordModel();
            model.Id = Convert.ToInt32(Request["Id"]);
            model.Word = txtWord.Text;

            BadWordRepository repository = new BadWordRepository();
            repository.Update(model);

            strDisplay.Text = "업데이트 완료";
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            (new BadWordRepository()).Remove(Convert.ToInt32(Request["Id"]));
            Response.Redirect("BadWordList.aspx");
        }
    }
}