using MemoEngine.Repositories;
using MemoEngine.ViewModels;
using System;
using System.Web.Mvc;
using System.Web.Security;

namespace MemoEngine.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(UserViewModel user)
        {
            user.DomainID = Request.Form["txtDomainID"];
            user.Name     = Request.Form["txtName"];
            user.Password = Request.Form["txtPassword"];
            user.Email    = Request.Form["txtEmail"];

            // ...

            UserRepository userRepo = new UserRepository();
            userRepo.AddUser(user); 

            return View("RegisterProcess");
        }

        public ActionResult RegisterProcess()
        {

            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            // 이미 로그인한 사용자라면, 메인페이지로 이동한다.
            if (Session["UserID"].ToString() != "Anonymous")
            {
                Response.RedirectPermanent("~/");
            }

            return View();
        }

        [HttpPost]
        public ActionResult Login(string txtUserID, string txtPassword)
        {
            string originLastLoginIp;
            DateTime originLastLoginDate;

            int result = (new UserRepository())
                .LoginUser(txtUserID, txtPassword, Request.UserHostAddress.Replace("::1", "127.0.0.1"), out originLastLoginIp, out originLastLoginDate);

            // 반환되어져 온 값을 세션에 담기
            Session["LastLoginDate"] = originLastLoginDate;
            Session["LastLoginIP"]   = originLastLoginIp;

            // 로그인 성공시
            if (result > 0)
            {
                // 로긴한 사용자의 정보를 읽어와서 세션 전역변수에 저장
                var userRepo = new UserRepository();
                var user = userRepo.GetUser(txtUserID);

                if (user != null)
                {
                    // 특정 사용자의 정보를 Application 전역 변수에 기록
                    System.Web.HttpContext.Current.Application.Lock();
                    System.Web.HttpContext.Current.Application["UserInfo@" + user.DomainID] = Session.SessionID + "!" + Request.ServerVariables["REMOTE_HOST"];
                    System.Web.HttpContext.Current.Application.UnLock();

                    Session["UID"]          = user.UID;                    
                    Session["UserID"]       = user.DomainID;
                    Session["UserName"]     = user.Name;
                    Session["UserEmail"]    = user.Email;
                    Session["LoginDate"]    = DateTime.Now;
                    Session["VisitedCount"] = user.VisitedCount;

                    // 현재 사용자가 속해 있는 그룹명 리스트를 '!' 구분자를 기준으로 문자열로 묶어서 출력
                    Session["GroupID"] = String.Join("!", (new GroupRepository()).GetGroupListsByUserId(Convert.ToInt32(Session["UID"])));

                    FormsAuthentication.SetAuthCookie(user.DomainID, false); // 폼 인증 부여
                }

                // 튕겨나온 페이지가 있다면, 로그인 후 해당 페이지로 다시 이동
                if (!String.IsNullOrEmpty(Request["ReturnUrl"]))
                {
                    Response.RedirectPermanent(Request["ReturnUrl"]);
                }

                // Response.RedirectPermanent("~/"); // 공통: 메인페이지로 이동
                // Response.RedirectPermanent("/Account/Greetings"); // 인삿말 페이지로 이동
                // return Redirect("~/"); // MVC: 메인 페이지로 이동
                return Redirect("/Account/Greetings"); // MVC: 인삿말 페이지로 이동
            }
            else
            {
                return View("Login");
            }
        }


        public ActionResult Greetings()
        {
            // 로그인하지 않은 사용자가 인삿말 페이지 접근시 Login 페이지로 튕김
            if (Session["UserID"].ToString() == "Anonymous" || Session["UserID"].ToString() == "")
            {
                //Response.RedirectPermanent("/Account/Login"); // Application["GREET_PAGE"]
                Response.RedirectPermanent(System.Web.HttpContext.Current.Application["LOGIN_PAGE"].ToString());
                Response.End(); 
            }

            return View();
        }


        public ActionResult UserInfor()
        {

            return View();
        }


    }
}
