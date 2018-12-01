using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DotNetNote.Modules.ScheduleByCommunity.Controls
{
    public partial class ScheduleByCommunityListControl : System.Web.UI.UserControl
    {
        private int _Year;
        private int _Month;

        public ScheduleByCommunityListControl()
        {
            _Year = DateTime.Now.Year;
            _Month = DateTime.Now.Month;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DisplayMonthlyData();
            }
        }

        private void DisplayMonthlyData()
        {
            if (Session["Community"] != null)
            {
                this.ctlMonthlyList.DataSource =
                    (new DatabaseProviderFactory()).Create("ConnectionString")
                        .ExecuteDataSet("GetScheduleByCommunityByMonthly",
                            Session["Community"].ToString(), _Year, _Month);
                this.ctlMonthlyList.DataBind();
            }
        }

        protected void btnWrite_Click(object sender, EventArgs e)
        {
            Response.Redirect("ScheduleByCommunityWrite.aspx");
        }
        protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
        {
            // 셀 사이즈 변경
            e.Cell.Width = 45;
            e.Cell.Height = 45;

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

                if (Session["Community"] != null)
                {
                    using (IDataReader objDr = (new DatabaseProviderFactory()).Create("ConnectionString").ExecuteReader("GetScheduleByCommunity", Session["Community"].ToString(), d.Date.Year, d.Date.Month, d.Date.Day))
                    {
                        while (objDr.Read())
                        {
                            string strTemp = objDr["Title"].ToString();
                            strNum = objDr["Num"].ToString();
                            strTitle += String.Format("<br /><div style='text-align:center;padding-top:5px;'><a href='ScheduleByCommunityView.aspx?SYear={0}&SMonth={1}&SDay={2}&Num={3}'><img src='icons/calendar.png' width='16' height='16' /></a></div>", d.Date.Year, d.Date.Month, d.Date.Day, strNum, strTemp);
                        }
                        if (!String.IsNullOrEmpty(strTitle)) // 해당 날짜에 데이터가 있다면
                        {
                            c.Controls.Add(new LiteralControl(strTitle));
                        }
                    }
                }
            }
        }
        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            //string strUrl = String.Format("ScheduleByCommunityWrite.aspx?SYear={0}&SMonth={1}&SDay={2}", this.Calendar1.SelectedDate.Year, this.Calendar1.SelectedDate.Month, this.Calendar1.SelectedDate.Day);
            //Response.Redirect(strUrl);
        }

        protected void Calendar1_VisibleMonthChanged(object sender, MonthChangedEventArgs e)
        {
            _Year = e.NewDate.Year;
            _Month = e.NewDate.Month;

            DisplayMonthlyData(); // 새롭게 변경된 날짜에 해당하는 리스트 출력
        }
    }
}