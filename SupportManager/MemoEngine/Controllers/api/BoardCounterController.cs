using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MemoEngine.Repositories;

namespace MemoEngine.Controllers
{
    public class BoardCounterController : ApiController
    {
        // GET: api/BoardCounter?boardName=Boards
        public string Get(string boardName)
        {
            BoardCounterRepository repo = new BoardCounterRepository();

            return repo.GetCountByBoardName(boardName).ToString(); 
        }
    }
}
