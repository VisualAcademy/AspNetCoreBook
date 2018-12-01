using MemoEngine.Models;
using MemoEngine.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MemoEngine.Controllers
{
    public class DivisionsController : ApiController
    {
        private DivisionRepository repository = new DivisionRepository();

        // GET: /api/divisions
        public List<Division> GetDivisions()
        {
            return this.repository.GetDivisions();
        }
    }
}
