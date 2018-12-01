using Reply.Bsl;
using System;
using System.Web.UI;

namespace MemoEngine.Reply
{
    public partial class List : System.Web.UI.Page
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
            this.ctlReplyList.DataSource = (new ReplyBiz()).SelectReply();
            this.ctlReplyList.DataBind();
        }

        /// <summary>
        /// step(숫자형)이 넘겨오면 그만큼 들여쓰기
        /// </summary>
        /// <param name="step">Object형</param>
        /// <returns>들여쓰기+Re이미지</returns>
        protected string FuncStep(object step)
        {
            int intStep = Convert.ToInt32(step);
            string result = String.Empty;
            for (int i = 0; i < intStep; i++) // 스텝만큼 들여쓰기
            {
                result += "&nbsp;&nbsp;";
            }
            if (intStep > 0) // 마지막에 Re 이미지 붙이기
            {
                result += "<img src='images/re.gif' />";
            }
            return result;
        }

        ///// <summary>
        ///// 날짜값을 받아서 24시간내의 글이면 New 이미지 붙이기
        ///// </summary>
        //protected string GetNewImg(object postDate)
        //{
        //    TimeSpan ts = DateTime.Now - Convert.ToDateTime(postDate);
        //    string result = "";
        //    if (ts.TotalHours < 24) // 24시간 내의 글이면...
        //    {
        //        result = "<img src='images/new.gif' />";
        //    }
        //    return result;
        //}
    }
}