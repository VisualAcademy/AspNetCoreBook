using MemoEngine.Models;
using System.Web.Mvc;

namespace MemoEngine.Controllers
{
    public class MaximController : Controller
    {
        private MaximServiceRepository repo = new MaximServiceRepository();

        // GET: Maxim
        public ActionResult Index()
        {
            return View(repo.GetMaxims());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Maxim model)
        {
            repo.AddMaxim(model);

            return RedirectToAction("Index", "Maxim");
        }
    }
}
