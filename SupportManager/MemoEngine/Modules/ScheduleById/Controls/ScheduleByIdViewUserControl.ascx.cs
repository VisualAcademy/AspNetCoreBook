using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace MemoEngine.Modules.ScheduleById.Controls
{
    public partial class ScheduleByIdViewUserControl : System.Web.UI.UserControl
    {
        #region Private Member Variables
        private string strSYear = DateTime.Now.Year.ToString(); // 년
        private string strSMonth = DateTime.Now.Month.ToString(); // 월
        private string strSDay = DateTime.Now.Day.ToString(); // 일
        private string strSHour = DateTime.Now.Hour.ToString(); // 시 
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            //// 최고 관리자 그룹만 쓰기 권한 부여
            //if (DotNetNote.DataProviders.UserController.HasGroup("Administrators"))
            //{
            //    btnModify.Visible = true;
            //    btnDelete.Visible = true;
            //}
            //else
            //{
            //    btnModify.Visible = false;
            //    btnDelete.Visible = false;
            //    // Response.Redirect("~/AccessDenied.aspx");//로그인 페이지로 이동	
            //}


            if (!Page.IsPostBack)
            {
                DisplayData();
            }
        }
        private void DisplayData()
        {
            #region 드롭다운 리스트 초기화
            // 년
            for (int i = (DateTime.Now.Year); i < (DateTime.Now.Year + 5); i++)
            {
                ListItem li = new ListItem();
                li.Text = i.ToString() + "년";
                li.Value = i.ToString();
                this.lstYear.Items.Add(li);
            }
            // 월
            for (int i = 1; i <= 12; i++)
            {
                ListItem li = new ListItem(String.Format("{0,2:D}월", i), i.ToString());
                this.ddlMonth.Items.Add(li);
            }
            // 일
            for (int i = 1; i <= 31; i++)
            {
                ListItem li = new ListItem(String.Format("{0}일", i), i.ToString());
                this.comDay.Items.Add(li);
            }
            // 시
            for (int i = 0; i <= 23; i++)
            {
                ListItem li = new ListItem(String.Format("{0}시", i), i.ToString());
                this.ctlHour.Items.Add(li);
            }
            #endregion

            #region 쿼리스트링 받기
            if (!String.IsNullOrEmpty(Request["SYear"]))
            {
                strSYear = Request["SYear"];
                strSMonth = Request["SMonth"];
                strSDay = Request["SDay"];
            }
            #endregion

            #region 넘겨온 값에 해당하는 일시를 선택
            foreach (ListItem item in this.lstYear.Items)
            {
                if (item.Value == strSYear) // 넘겨온 년도와 같다면...
                {
                    item.Selected = true; // 해당 항목이 선택된 상태로 보여주기	
                }
            }
            for (int i = 0; i < this.ddlMonth.Items.Count; i++)
            {
                if (this.ddlMonth.Items[i].Value == strSMonth)
                {
                    this.ddlMonth.Items[i].Selected = true;
                }
            }
            foreach (ListItem li in this.comDay.Items)
            {
                if (li.Value == strSDay)
                {
                    li.Selected = true;
                }
            }
            for (int i = 0; i < ctlHour.Items.Count; i++)
            {
                if (ctlHour.Items[i].Value == DateTime.Now.Hour.ToString())
                {
                    ctlHour.Items[i].Selected = true;
                }
            }
            #endregion

            #region 제목과 내용 출력
            using (IDataReader objDr = (new DatabaseProviderFactory()).Create("ConnectionString").ExecuteReader("ViewScheduleById", "", Request["Num"]))
            {
                if (objDr.Read())
                {
                    txtTitle.Text = objDr["Title"].ToString();
                    txtContent.Text = objDr["Content"].ToString();
                }
                objDr.Close();
            }
            #endregion
        }
        protected void btnModify_Click(object sender, EventArgs e)
        {
            (new DatabaseProviderFactory()).Create("ConnectionString").ExecuteNonQuery("ModifyScheduleById", "", this.lstYear.SelectedValue, this.ddlMonth.SelectedValue, this.comDay.SelectedValue, this.ctlHour.SelectedValue, txtTitle.Text, txtContent.Text, Request["Num"]);
            btnList_Click(null, null);
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            (new DatabaseProviderFactory()).Create("ConnectionString").ExecuteNonQuery("DeleteScheduleById", "", Request["Num"]);
            btnList_Click(null, null);
        }
        protected void btnList_Click(object sender, EventArgs e)
        {
            string strUrl = String.Format("ScheduleByIdList.aspx?SYear={0}&SMonth={1}", strSYear, strSMonth);
            Response.Redirect(strUrl);
        }
    }
}