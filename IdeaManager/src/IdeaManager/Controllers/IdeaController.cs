using IdeaManager.Models;
using Microsoft.AspNetCore.Mvc;

namespace IdeaManager.Controllers
{
    public class IdeaController : Controller
    {
        private IIdeaRepository _repository;
        public IdeaController(IIdeaRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            return View(_repository.GetAll());
        }

        [HttpPost]
        public IActionResult Index(Idea model)
        {
            _repository.Add(model);
            return RedirectToAction(nameof(Index));
        }
    }
}
