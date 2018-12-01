using MemoEngine.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MemoEngine.Tests
{
    public partial class FrmGetGroupListsByUserId : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var repo = new GroupRepository();

            var str = String.Join("!", repo.GetGroupListsByUserId(5));

            Response.Write(str);
            Response.End();
        }
    }
}