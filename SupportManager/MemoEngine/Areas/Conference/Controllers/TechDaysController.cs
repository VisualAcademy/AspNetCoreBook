using MemoEngine.Models;
using MemoEngine.Areas.Conference.Services;
using System;
using System.Linq;
using System.Web.Mvc;

namespace MemoEngine.Areas.Conference.Controllers
{
    public class TechDaysController : Controller
    {

        /// <summary>
        /// 의존성 주입
        /// </summary>
        private IMailService _mail;

        public TechDaysController(IMailService mail)
        {
            _mail = mail; 
        }

        // GET: Conference
        public ActionResult Index()
        {
            ViewBag.Message = "";

            // View 페이지로 전체 세션 카운트 넘겨주기
            ViewBag.NumSessions = SessionRepository.All.Count;

            return View();
        }

        public ActionResult AngularSpa()
        {
            ViewBag.Message = "SPA 버전";

            return View(); 
        }

        public ActionResult AjaxCallWithJavaScriptQuery()
        {
            ViewBag.Message = "jQuery 버전";

            return View();
        }


        public ActionResult AllSessions()
        {
            ViewBag.Message = "전체 세션 리스트";

            // 전체 세션 제목을 중복 제거 후 오름차순으로 정렬해서 보여줌
            var allSessions = SessionRepository.All.Select(x => x.Title).Distinct().OrderBy(x => x);

            return View(allSessions); 
        }

        public ViewResult AllSpeakers()
        {
            ViewBag.Message = "전체 발표자 리스트";

            // 모든 발표자 리스트 출력
            var allSpeakers = SessionRepository.All.SelectMany(x => x.Speakers).Distinct().OrderBy(x => x);

            return View(allSpeakers);
        }

        public ViewResult AllCommunities()
        {
            ViewBag.Message = "전체 커뮤니티 리스트";

            var allCommunities = SessionRepository.All.Select(x => x.Community).Distinct().OrderBy(x => x);

            return View(allCommunities);
        }

        public ViewResult AllTags()
        {
            ViewBag.Message = "전체 태그 리스트";

            var allTags = SessionRepository.All.SelectMany(x => x.Tags).Distinct().OrderBy(x => x);

            return View(allTags);
        }

        public ViewResult AllDates()
        {
            ViewBag.Message = "날짜별 세션 리스트";

            var allDates = SessionRepository.All.OrderBy(x => x.StartDate).Select(x => x.StartDate).Distinct();

            return View(allDates);
        }

        // 모모모별 세션 정보 리스트(테이블) : XXXByXXX => 공통 페이지 : SessionsTable.cshtml
        public ViewResult SessionsByDate(DateTime date)
        {
            ViewBag.Title = "세션 시작 시간 : " + date.ToShortTimeString();
            var sessions = SessionRepository.All.Where(x => x.StartDate == date).OrderBy(x => x.StartDate);
            return View("SessionsTable", sessions);
        }


        public ViewResult SessionsBySpeaker(string speaker)
        {
            ViewBag.Title = "세션 발표자 : " + speaker;
            var sessions = SessionRepository.All.Where(session => session.Speakers.Contains(speaker)).OrderBy(x => x.StartDate);
            return View("SessionsTable", sessions);
        }

        public ViewResult SessionsByCommunity(string community)
        {
            ViewBag.Title = "세션 발표 커뮤니티 : " + community;
            var sessions = SessionRepository.All.Where(session => session.Community.Contains(community)).OrderBy(x => x.StartDate);
            return View("SessionsTable", sessions);
        }

        public ViewResult SessionsByTag(string tag)
        {
            ViewBag.Title = "세션 태그 : " + tag;
            var sessions = SessionRepository.All.Where(session => session.Tags.Contains(tag)).OrderBy(x => x.Title);
            return View("SessionsTable", sessions);
        }

        // 세션 상세 보기 : 모든 링크의 최종 종착점
        public ActionResult SessionByCode(string code)
        {
            if (String.IsNullOrEmpty(code))
            {
                return RedirectToAction("AllTags"); // 특정 뷰로 이동
            }

            var session = SessionRepository.All.Single(s => s.Code == code);
            return View(session);
        }


        /// <summary>
        /// 연락처 페이지 Get
        /// </summary>
        public ActionResult Contact() 
        {
            ViewBag.Message = "연락처 페이지";

            return View(); 
        }

        /// <summary>
        /// 연락처 페이지 Post
        /// </summary>
        [HttpPost]
        public ActionResult Contact(ContactModel model)
        {
            var msg = string.Format("Comment From: {1}{0}Email:{2}{0}Website: {3}{0}Comment:{4}",
              Environment.NewLine,
              model.Name,
              model.Email,
              model.Website,
              model.Comment);

            if (_mail.SendMail("noreply@yourdomain.com", "foo@yourdomain.com", "Website Contact", msg))
            {
                ViewBag.MailSent = true;
            }

            return View();
        }

    }
}