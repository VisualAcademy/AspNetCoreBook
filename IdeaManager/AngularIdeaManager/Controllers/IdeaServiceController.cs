using IdeaManager.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace AngularIdeaManager.Controllers
{
    [Route("api/[controller]")]
    public class IdeaServiceController : Controller
    {
        private IIdeaRepository repository;

        public IdeaServiceController(IIdeaRepository repo)
        {
            repository = repo;
        }

        [HttpGet]
        public IEnumerable<Idea> Get()
        {
            return repository.GetAll().AsEnumerable(); 
        }

        [HttpPost]
        public JsonResult Post([FromBody]Idea model)
        {
            var m = repository.Add(model);
            return Json(m); 
        }
    }
}
