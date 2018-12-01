using MemoEngine.Models;
using MemoEngine.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MemoEngine.Modules.BadWord
{
    public partial class BadWordCheck : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCheck_Click(object sender, EventArgs e)
        {
            string strInput = txtInput.Text;
            if ((new BadWordRepository()).IsExists(strInput))
            {
                lblDisplay.Text = "비속어가 포함되어 있습니다.";
            }
            else
            {
                lblDisplay.Text = "비속어가 포함되어 있지않습니다.";
            }
        }

        //private bool IsExists(string strInput)
        //{
        //    bool r = false; 

        //    List<BadWordModel> words = (new BadWordRepository()).GetBadWords();
        //    foreach (var word in words)
        //    {
        //        if (strInput.Contains(word.Word))
        //        {
        //            return true;
        //        }
        //    }

        //    return r;
        //}
    }
}