using Microsoft.AspNetCore.Mvc;

namespace Welfare.Controllers
{
    public class ChildrenController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
