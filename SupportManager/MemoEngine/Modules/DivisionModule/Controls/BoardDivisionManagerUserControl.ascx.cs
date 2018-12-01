using MemoEngine.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MemoEngine.Modules.DivisionModule.Controls
{
    public partial class BoardDivisionManagerUserControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DisplayDivisionList();
            }
        }

        private void DisplayDivisionList()
        {
            DivisionRepository repo = new DivisionRepository();

            this.ddlDivisionList.DataSource = repo.GetDivisions();
            ddlDivisionList.DataTextField = "DivisionName";
            ddlDivisionList.DataValueField = "DivisionId";
            this.ddlDivisionList.DataBind(); 
        }

        protected void ctlBoardList_SelectedIndexChanged(object sender, EventArgs e)
        {
            // GridView에서 선택된 레코드의 값에 해당하는 DataKey(기본설정값)를 읽어오기
            txtTID.Text = ctlBoardList.SelectedDataKey.Value.ToString();

            //[!] 선택된 특정 셀의 텍스트 값 읽어오기
            lblBoardName.Text = ctlBoardList.SelectedRow.Cells[3].Text; 
        }

        protected void btnAddBoardDivision_Click(object sender, EventArgs e)
        {
            int tid = Convert.ToInt32(txtTID.Text);

            //FROM: int divisionId = Convert.ToInt32(Request.Form["BoardDivisionManagerUserControl$DivisionListUserControl$lstDivisionsUserControl"]);
            //TO: FIX: 폼 관련 태그의 name 속성이 자동으로 바뀌는 문제때문에 서버 컨트롤로 대체
            int divisionId = Convert.ToInt32(ddlDivisionList.SelectedValue); 

            BoardDivisionRepository repo = new BoardDivisionRepository();
            var id = repo.AddBoardDivision(tid, divisionId);

            lblId.Text = String.Format("{0}번 레코드가 등록되었습니다. ", id);
        }
    }
}