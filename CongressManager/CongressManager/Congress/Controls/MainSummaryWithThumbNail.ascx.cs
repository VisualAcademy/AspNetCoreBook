using All;
using Hawaso.Standard;
using System;
using System.Collections.Generic;

namespace CongressManager.Congress.Controls
{
    public partial class MainSummaryWithThumbNail : System.Web.UI.UserControl
    {
        public List<ArticleBase> Model { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            DisplayData();
        }

        private void DisplayData()
        {
            var repository = new CongressRepository();

            Model = repository.GetAll(0, 5); // 썸네일 4개 가져오기 
        }
    }
}
