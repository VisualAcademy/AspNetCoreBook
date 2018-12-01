using Microsoft.AspNetCore.Mvc;

namespace Welfare.Controllers
{
    public class GuardiansController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details(int id)
        {
            ViewData["Id"] = id; 

            return View();
        }
    }
}
