using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DotNetNote.Modules.ScheduleByDomain.Controls
{
    public partial class ScheduleByDomainListControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Empty : 인증과 연동(관리자만 글쓰기 버튼 보이기)
        }
        protected void btnWrite_Click(object sender, EventArgs e)
        {
            Response.Redirect("ScheduleByDomainWrite.aspx");
        }
        protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
        {
            CalendarDay d = e.Day;// 현재 날짜
            TableCell c = e.Cell;// 현재 셀(td)

            if (d.IsOtherMonth) // 다른 월이라면...
            {
                c.Controls.Clear(); // 셀 클리어	
            }
            else
            {
                string strTitle = "";
                string strNum = "";//일련번호
                using (IDataReader objDr = (new DatabaseProviderFactory()).Create("ConnectionString").ExecuteReader("GetScheduleByDomain", Session["UserID"].ToString(), d.Date.Year, d.Date.Month, d.Date.Day))
                {
                    while (objDr.Read())
                    {
                        string strTemp = objDr["Title"].ToString();
                        strNum = objDr["Num"].ToString();
                        strTitle += String.Format("<br /><a href='ScheduleByDomainView.aspx?SYear={0}&SMonth={1}&SDay={2}&Num={3}'>{4}</a>", d.Date.Year, d.Date.Month, d.Date.Day, strNum, strTemp);
                    }
                    if (!String.IsNullOrEmpty(strTitle)) // 해당 날짜에 데이터가 있다면
                    {
                        c.Controls.Add(new LiteralControl(strTitle));
                    }
                }
            }
        }
        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            string strUrl = String.Format("ScheduleByDomainWrite.aspx?SYear={0}&SMonth={1}&SDay={2}", this.Calendar1.SelectedDate.Year, this.Calendar1.SelectedDate.Month, this.Calendar1.SelectedDate.Day);
            Response.Redirect(strUrl);
        }
    }
}