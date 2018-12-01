using System;
using System.Web.Security;

namespace MemoEngine
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // 만약, 웹브라우저를 그냥 닫으면, 자동로그인 살아있고, 로그아웃 버튼을 클릭하면 자동로그인 기능 해제
            Response.Cookies["UserID"].Expires = DateTime.Now.AddDays(-1);
            Response.Cookies["Password"].Expires = DateTime.Now.AddDays(-1);

            // 폼인증 제거
            FormsAuthentication.SignOut(); 

            // 애플리케이션 전역 변수에서 현재 사용자 정보 삭제
            Application["UserInfo@" + Session["UserID"].ToString()] = null; 

            // 현재 사용자 세션 정보 클리어(로그아웃)
            Session.Abandon();


            // 익명 사용자으로 초기화
            Session["UID"] = 7;
            Session["UserID"] = "Anonymous";
            Session["UserName"] = "익명 사용자";


            // 메인 페이지로 이동
            Response.RedirectPermanent("~/Default.aspx"); 
        }
    }
}
