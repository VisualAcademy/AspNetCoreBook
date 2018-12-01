using Hawaso.Standard;
using System;

namespace CongressManager.Congress
{
    public partial class CongressWrite : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // 게시판 입력 페이지로 지정
            ctlBoardEditorFormControl.FormType = BoardWriteFormType.Write;
        }
    }
}
