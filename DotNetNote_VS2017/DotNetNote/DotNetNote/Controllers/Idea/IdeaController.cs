using DotNetNote.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotNetNote.Controllers
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
            var ideas = _repository.GetAll();
            return View(ideas);
        }

        [HttpPost]
        public IActionResult Index(Idea model)
        {
            model = _repository.Add(model);
            return RedirectToAction(nameof(Index));
        }
    }
}
