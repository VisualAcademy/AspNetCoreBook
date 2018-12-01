using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DevDataControl
{
    public partial class FrmDataListWithCheckBox : System.Web.UI.Page
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
            List<BoardBase> boards = new List<BoardBase>();
            boards.Add(new BoardBase { TID = 1, BoardAlias = "Notice", Menu = true });
            boards.Add(new BoardBase { TID = 2, BoardAlias = "Free", Menu = false });
            boards.Add(new BoardBase { TID = 3, BoardAlias = "Photo", Menu = true });

            this.ctlBoardList.DataSource = boards;
            this.ctlBoardList.DataBind(); 
        }

        protected void chkMenu_CheckedChanged(object sender, EventArgs e)
        {
            if (sender != null)
            {
                try
                {
                    // 클릭된 체크박스 가져오기 
                    var chk = sender as CheckBox;

                    // 현재 체크박스가 포함된 DataListItem 가져오기 
                    DataListItem item = (DataListItem)chk.NamingContainer;
                                        
                    // 현재 열에 있는 히든필드의 값을 가져오기
                    var hdn = ctlBoardList.Items[item.ItemIndex].FindControl("hdnBoardAlias") as HiddenField; 

                    // 현재 선택한 체크박스가 체크되었다면,
                    lblCheckedValue.Text = $"{chk.Text} - {chk.Checked} - {hdn.Value}";
                }
                catch (Exception)
                {
                    
                }
            }
        }
    }

    public class BoardBase
    {
        public int TID { get; set; }
        public string BoardAlias { get; set; }
        public bool Menu { get; set; }
    }
}
