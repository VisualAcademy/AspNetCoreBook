using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MemoEngine.Controllers
{
    public class RazorDemoController : Controller
    {
        // GET: RazorDemo
        public ActionResult Index()
        {
            return View();
        }
    }
}