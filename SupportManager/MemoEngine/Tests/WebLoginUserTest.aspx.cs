using MemoEngine.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MemoEngine.Tests
{
    public partial class WebLoginUserTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UserRepository repo = new UserRepository();


            string ip;
            DateTime date;

            int r = repo.LoginUser("blue", "1234", "127.0.0.1", out ip, out date);

            if (r == 1)
            {
                Response.Write("로그인 성공");
            }
            else
            {
                Response.Write("로그인 실패");
            }
        }
    }
}