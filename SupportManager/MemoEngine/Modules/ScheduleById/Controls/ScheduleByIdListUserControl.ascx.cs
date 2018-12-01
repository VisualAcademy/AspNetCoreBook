using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace MemoEngine.Modules.ScheduleById.Controls
{
    public partial class ScheduleByIdListUserControl : System.Web.UI.UserControl
    {
        private int _Year;
        private int _Month;
        private int _Day;

        string sYear;
        string sMonth;
        string sDay;

        public ScheduleByIdListUserControl()
        {
            _Year = DateTime.Now.Year;
            _Month = DateTime.Now.Month;
            _Day = DateTime.Now.Day;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            sYear = Request.QueryString["SYear"];
            sMonth = Request.QueryString["SMonth"];
            sDay = Request.QueryString["SDay"];

            if (!Page.IsPostBack)
            {
                DisplayMonthlyData();
            }

            Calendar1.BorderWidth = Unit.Pixel(0);
        }

        private void DisplayMonthlyData()
        {
                //// 이번달 일정 가져오기
                //this.ctlMonthlyList.DataSource = (new DatabaseProviderFactory()).Create("ConnectionString").ExecuteDataSet("GetScheduleByIdByMonthly", "", _Year, _Month);
                // 이전 5일 앞으로 9일간의 일정 가져오기
                /*
                // 만약에 이번달이면, 이번달 일정을 보여주고, 다른 달이면, 전체 일정 보여주기
                if (Calendar1.SelectedDate.Month == _Month)
                {
                    this.ctlMonthlyList.DataSource = (new DatabaseProviderFactory()).Create("ConnectionString").ExecuteDataSet("GetScheduleByIdByCurrentWeek", "");
                    this.ctlMonthlyList.DataBind();

                    this.lstMonthlyList.DataSource = (new DatabaseProviderFactory()).Create("ConnectionString").ExecuteDataSet("GetScheduleByIdByCurrentWeek", "");
                    this.lstMonthlyList.DataBind();
                }
                else
                {
                    this.lstMonthlyList.DataSource = (new DatabaseProviderFactory()).Create("ConnectionString").ExecuteDataSet("GetScheduleById", "", _Year, _Month, "14");
                    this.lstMonthlyList.DataBind();
                }
                */

                // 처음 로드시에는 이번 주 일정만 가져오기 
                if (String.IsNullOrEmpty(Request["SYear"]))
                {
                    //this.lstMonthlyList.DataSource = (new DatabaseProviderFactory()).Create("ConnectionString").ExecuteDataSet("GetScheduleById", "", _Year, _Month, _Day);
                    //this.lstMonthlyList.DataBind();
                    this.lstMonthlyList.DataSource = (new DatabaseProviderFactory()).Create("ConnectionString").ExecuteDataSet("GetScheduleByIdByCurrentWeek", "");
                    this.lstMonthlyList.DataBind();
                }
                else
                {
                    this.lstMonthlyList.DataSource = (new DatabaseProviderFactory()).Create("ConnectionString").ExecuteDataSet("GetScheduleById", "", sYear, sMonth, sDay);
                    this.lstMonthlyList.DataBind();
                }

        }

        protected void btnWrite_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Modules/ScheduleById/ScheduleByIdWrite.aspx");
        }

        protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
        {
            // 각 날짜의 셀에 대한 테두리 색상
            e.Cell.BorderWidth = Unit.Pixel(1);
            e.Cell.BorderStyle = BorderStyle.Solid;
            e.Cell.BorderColor = Color.FromName("#d3d3d3");

            // 셀 사이즈 변경
            e.Cell.Width = 40;
            e.Cell.Height = 40;

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

                    using (IDataReader objDr = (new DatabaseProviderFactory()).Create("ConnectionString").ExecuteReader("GetScheduleById", "", d.Date.Year, d.Date.Month, d.Date.Day))
                    {
                        while (objDr.Read())
                        {
                            string strTemp = objDr["Title"].ToString();
                            strNum = objDr["Num"].ToString();

                            strTitle = String.Format("<br /><div style='text-align:center;padding-top:5px;'><a href='{4}ScheduleByIdView.aspx?SYear={0}&SMonth={1}&SDay={2}&Num={3}'><i class='glyphicon glyphicon-calendar'></i></a></div>", d.Date.Year, d.Date.Month, d.Date.Day, strNum, "");

                        }
                        if (!String.IsNullOrEmpty(strTitle)) // 해당 날짜에 데이터가 있다면
                        {
                            e.Cell.BackColor = Color.FromName("#ededed");
                            c.Controls.Add(new LiteralControl(strTitle));
                        }
                    }
            }
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            string strUrl = String.Format("ScheduleByIdView.aspx?SYear={0}&SMonth={1}&SDay={2}", this.Calendar1.SelectedDate.Year, this.Calendar1.SelectedDate.Month, this.Calendar1.SelectedDate.Day);
            Response.Redirect(strUrl);
        }

        protected void Calendar1_VisibleMonthChanged(object sender, MonthChangedEventArgs e)
        {
            _Year = e.NewDate.Year;
            _Month = e.NewDate.Month;

            DisplayMonthlyDataChange(); // 새롭게 변경된 날짜에 해당하는 리스트 출력
        }


        private void DisplayMonthlyDataChange()
        {
                // 처음 로드시에는 이번 주 일정만 가져오기 
                if (String.IsNullOrEmpty(Request["SYear"]))
                {
                    this.lstMonthlyList.DataSource = (new DatabaseProviderFactory()).Create("ConnectionString").ExecuteDataSet("GetScheduleById", "", sYear, sMonth, sDay);
                    this.lstMonthlyList.DataBind();
                }
                else
                {
                    this.lstMonthlyList.DataSource = (new DatabaseProviderFactory()).Create("ConnectionString").ExecuteDataSet("GetScheduleById", "", sYear, sMonth, sDay);
                    this.lstMonthlyList.DataBind();
                }
        }
    }
}