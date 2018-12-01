using System.Collections.Generic;
using System.Web.Http;

namespace MemoEngine.Controllers
{
    public class JavaScriptQueryDemoController : ApiController
    {
        public List<JavaScriptQueryDemoClass> Get()
        {
            return new List<JavaScriptQueryDemoClass>(){
                new JavaScriptQueryDemoClass { Id = 1, Name ="김태영" },
                new JavaScriptQueryDemoClass { Id = 2, Name = "박용준" },
                new JavaScriptQueryDemoClass { Id = 3, Name = "한상훈" }
            };
        }
    }

    public class JavaScriptQueryDemoClass
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
