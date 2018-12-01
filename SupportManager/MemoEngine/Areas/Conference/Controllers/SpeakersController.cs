using MemoEngine.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace MemoEngine.Areas.Conference.Controllers
{
    public class SpeakersController : ApiController
    {
        [HttpGet]
        public IEnumerable<Speaker> Get()
        {
            // 아래 코드 영역은 언제든지 DB에서 가져오는 값으로 대체할 수 있음
            var lst = new List<Speaker>();

            lst.Add(new Speaker { Id = 1, Name = "박용준 MVP", Photo = "박용준 MVP", Title = "MVP", Description = "데브렉 전임강사" });
            lst.Add(new Speaker { Id = 2, Name = "김태영 부장", Photo = "김태영 부장", Title = "Microsoft", Description = "한국마이크로소프트 DX, Technical Evangelist" });
            lst.Add(new Speaker { Id = 3, Name = "김명신 부장", Photo = "김명신 부장", Title = "Microsoft", Description = "한국마이크로소프트 DX, Technical Evangelist" });
            lst.Add(new Speaker { Id = 4, Name = "한상훈 MVP", Photo = "한상훈 MVP", Title = "MVP", Description = "넥슨 개발자" });
            lst.Add(new Speaker { Id = 5, Name = "성지용 부장", Photo = "성지용 부장", Title = "Microsoft", Description = "한국마이크로소프트 DX, Technical Evangelist" });

            return lst; 
        }
    }
}
