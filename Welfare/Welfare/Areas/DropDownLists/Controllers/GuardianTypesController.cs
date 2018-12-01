using Microsoft.AspNetCore.Mvc;

namespace Welfare.Areas.DropDownLists.Controllers
{
    [Area("DropDownLists")]
    public class GuardianTypesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
