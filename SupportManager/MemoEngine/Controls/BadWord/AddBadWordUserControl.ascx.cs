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
    public partial class AddBadWordUserControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAddBadWord_Click(object sender, EventArgs e)
        {
            var badWord = new BadWordModel();
            badWord.Word = txtBadWord.Text.Trim(); 

            var repo = (new BadWordRepository());
            repo.AddBadWord(badWord);

            Response.Redirect("BadWordList.aspx");
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string word = txtWord.Text;

            var model = new BadWordModel();
            model.Word = word;

            model = (new BadWordRepository()).AddBadWordUpgrade(model);

            this.lblDisplay.Text = String.Format("{0}번 레코드가 저장됨", model.Id);
        }

        protected void btnAddMulti_Click(object sender, EventArgs e)
        {
            // Bulk Insert
            string src = txtWords.Text;
            string[] lines = src.Split('\n');

            List<BadWordModel> records = new List<BadWordModel>();
            foreach (var line in lines)
            {
                string s = line.Replace("\n", "").Replace("\r", "");
                if (s.Length > 0)
                {
                    records.Add(new BadWordModel { Word = s.Trim() });
                }
            }

            // Repository 호출
            (new BadWordRepository()).BulkInsertBadWord(records);

            // 마무리
            this.lblError.Text = "입력되었습니다.";
        }
    }
}