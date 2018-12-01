using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace MemoEngine.Controllers
{
    public class DemoController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CustomHelperDemo()
        {
            return View();
        }

        public ActionResult DropDownListSelectListDemo()
        {            
            var data = new List<NameDemo>() {
                new NameDemo() {
                    Id = 1, Name = "홍길동"
                },
                new NameDemo() {
                    Id = 2, Name = "백두산"
                }
            };

            var vm = new NameViewModelDemo()
            {
                NameDemos = data
            };
            return View(vm);
        }
    }

    public class NameDemo
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class NameViewModelDemo
    {
        [Display(Name = "번호")]
        public int Id { get; set; }
        [Display(Name = "이름들")]
        public int NameDemo { get; set; }
        public IEnumerable<NameDemo> NameDemos { get; set; }
    }


}