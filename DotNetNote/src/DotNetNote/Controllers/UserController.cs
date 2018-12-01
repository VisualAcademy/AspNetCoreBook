//[User][6]
using DotNetNote.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DotNetNote.Controllers
{
    public class UserController : Controller
    {
        //[User][6][1]
        private IUserRepository _repository;

        public UserController(IUserRepository repository)
        {
            _repository = repository;
        }
        

        //[User][6][2]
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }


        //[User][6][3] : ȸ�� ���� ��
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        //[User][6][4] : ȸ�� ���� ó��
        [HttpPost]
        public IActionResult Register(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (_repository.GetUserByUserId(model.UserId).UserId != null)
                {
                    ModelState.AddModelError("", "�̹� ���Ե� ������Դϴ�.");
                    return View(model);
                }
            }

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "�߸��� ���� �õ�!!!");
                return View(model);
            }
            else
            {
                _repository.AddUser(model.UserId, model.Password);
                return RedirectToAction("Index");
            }
        }


        //[User][6][5] : �α��� ��
        [HttpGet]
        [AllowAnonymous] // �������� ���� ����ڵ� ���� ����
        public IActionResult Login(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        //[User][6][6] : �α��� ó��
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(
            UserViewModel model, string returnUrl = null)
        {
            if (ModelState.IsValid)
            {
                if (_repository.IsCorrectUser(model.UserId, model.Password))
                {
                    //[!] ���� �ο�
                    var claims = new List<Claim>()
                    {
                        // �α��� ���̵� ����
                        new Claim("UserId", model.UserId),

                        // �⺻ ���� ����, "Role" ��ɿ� "Users" �� �ο�
                        new Claim(ClaimTypes.Role, "Users") // �߰� ���� ���
                    };

                    var ci = new ClaimsIdentity(claims, model.Password);

                    await HttpContext.Authentication.SignInAsync(
                        "Cookies", new ClaimsPrincipal(ci));

                    return LocalRedirect("/User/Index");
                }
            }

            return View(model);
        }


        //[User][6][7] : �α׾ƿ� ó��
        public async Task<IActionResult> Logout()
        {
            // Startup.cs�� �̵����� ������ "Cookies" �̸� ���
            await HttpContext.Authentication.SignOutAsync("Cookies");

            return Redirect("/User/Index");
        }


        //[User][6][8] : ȸ�� ���� ���� �� ����
        [Authorize]
        public IActionResult UserInfor()
        {
            return View();
        }

        //[User][6][9] : �λ縻 ������
        public IActionResult Greetings()
        {
            //[Authorize] Ư���� �� �ٸ� ǥ�� ���
            // �������� ���� ����ڴ�
            if (User.Identity.IsAuthenticated == false)
            {
                // �α��� �������� ���𷺼�
                return new ChallengeResult();
            }

            return View();
        }

        //[User][6][10] : ���� �ź� ������
        public IActionResult Forbidden()
        {
            return View();
        }
    }
}
