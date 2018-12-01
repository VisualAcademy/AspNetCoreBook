using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Welfare.Models;

namespace Welfare.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            var dashboards = new List<DashboardViewModel>()
            {
                new DashboardViewModel { Id = 1, Name = "홍길동" },
                new DashboardViewModel { Id = 2, Name = "백두산" },
                new DashboardViewModel { Id = 3, Name = "임꺽정" }
            };

            ViewBag.Dashboards = dashboards; // 컨트롤러에서 뷰로 데이터 전송

            return View();
        }
    }
}
