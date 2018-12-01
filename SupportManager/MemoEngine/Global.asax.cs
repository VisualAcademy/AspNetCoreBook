using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Http;
using System.Globalization;
using System.Threading;
using MemoEngine.Repositories;

namespace MemoEngine
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            //[!] ASP.NET 4.5 이상에서 유효성 검사 컨트롤 사용하기
            //[1] PM> Install-Package jQuery
            //[2] PM> Install-Package AspNet.ScriptManager.jQuery
            //[3] Global.asax - Application_Start()
            System.Web.UI.ValidationSettings.UnobtrusiveValidationMode = 
                System.Web.UI.UnobtrusiveValidationMode.WebForms;

            // 응용 프로그램 시작 시 실행되는 코드
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes); // Friendly URLs 구현을 위한 기본 코드


            //-------------------------------------------------------------------------------------
            // MemoEngine Configuration
            //-------------------------------------------------------------------------------------

            Application["SITE_NAME"]  = System.Configuration.ConfigurationManager.AppSettings["SITE_NAME"].ToString(); // 현재 사이트 이름
            Application["GREET_PAGE"] = System.Configuration.ConfigurationManager.AppSettings["GREET_PAGE"].ToString();
            Application["LOGIN_PAGE"] = System.Configuration.ConfigurationManager.AppSettings["LOGIN_PAGE"].ToString();


            //-------------------------------------------------------------------------------------
            // End of configuration
            //-------------------------------------------------------------------------------------


            //[DevStateManagement] 응용 프로그램이 시작될 때 실행되는 코드입니다.
            Application["Now"] = DateTime.Now;
        }

        void Session_Start(object sender, EventArgs e)
        {
            // 세션 유지시간 2시간
            Session.Timeout = 120;

            // 로그인 후에 해당 사용자의 정보 값으로 대체
            Session["UID"] = 7;
            Session["UserID"] = "Anonymous"; 
            Session["UserName"] = "손님";

            // 현재 사용자가 속해 있는 그룹명 리스트를 '!' 구분자를 기준으로 문자열로 묶어서 출력
            Session["GroupID"] = String.Join("!", (new GroupRepository()).GetGroupListsByUserId(Convert.ToInt32(Session["UID"])));
            //SqlConnection objCon = new SqlConnection();
            //objCon.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            //objCon.Open();

            //SqlCommand objCmd = new SqlCommand();
            //objCmd.Connection = objCon;

            //string strSql = "SELECT DomainID As GroupID FROM Domains WHERE Domains.UID IN (SELECT GroupUID FROM Membership, Users WHERE Membership.UserUID = Users.UID AND Users.UID = " + Session["UID"] + ")";
            //objCmd.CommandText = strSql;
            //objCmd.CommandType = CommandType.Text;

            //SqlDataReader objDr = objCmd.ExecuteReader();

            //string strGroup = String.Empty;
            //while (objDr.Read())
            //{
            //    strGroup += objDr["GroupID"].ToString() + "!";
            //}

            //objDr.Close();
            //objCon.Close();

            //Session["GroupID"] = strGroup;

            //[DevStateManagement] 새 세션이 시작할 때 실행되는 코드입니다.
            Session["Now"] = DateTime.Now;
        }

        void Session_End(object sender, EventArgs e)
        {

        }

        // ASP.NET MVC Manual Configuration in Global.asax - Localization
        void Application_BeginRequest(object sender, EventArgs e)
        {
            //var culture = new CultureInfo("en-US"); // 특정 언어로 시작하고자할 때에 값을 지정
            var culture = CultureInfo.CurrentUICulture;

            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;
        }

        void Application_End(object sender, EventArgs e)
        {
            // Empty
        }
    }
}