using System;
using System.Web.UI;
using MemoEngine.Repositories;

namespace MemoEngine.Tests
{
    public partial class FrmEventFirst : System.Web.UI.Page
    {
        EventFirstRepository repo = new EventFirstRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
            // 로그인한 사용자만 접근하도록 설정
            //if (Session["UserID"].ToString() == "Anonymous")
            //{
            //    Response.Redirect("/Account/Login"); 
            //}

            if (!Page.IsPostBack)
            {
                int id = 0;
                //[!] 아래 for문은 동시에 10000명이 현재 페이지를 동시에 로드했다고 가정: 데이터가 0일때에는 금방 뜸. 
                //for (int i = 0; i < 10000; i++)
                //{
                id = repo.GetEventById(Session["UID"].ToString());
                //}
                if (id > 0)
                {
                    this.btnEvent.Text = id + "번으로 등록되었습니다.";
                    this.btnEvent.Enabled = false; 
                }
                else
                {
                    this.btnEvent.Text = "이벤트 등록하기";
                    this.btnEvent.Enabled = true;
                }
            }
        }

        protected void btnEvent_Click(object sender, EventArgs e)
        {
            //[!] 아래 for문은 동시에 10000명이 등록 버튼을 클릭했다고 가정
            //for (int i = 0; i < 10000; i++)
            //{
                repo.AddEvent(Session["UID"].ToString());
            //}

            this.btnEvent.Text = "등록되었습니다.";
            this.btnEvent.Enabled = false;
        }
    }
}
