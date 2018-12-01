using MemoEngine.Models;
using System.Web.Mvc;

namespace MemoEngine.Controllers
{
    public class TasksController : Controller
    {
        private TaskModelRepository _repository;

        public TasksController()
        {
            _repository = new TaskModelRepository();
        }

        // 할 일 목록 표시
        public ActionResult Index()
        {
            // 리스트 출력
            var r = _repository.GetTasks();

            return View(r);
        }

        // 할 일 등록
        public ActionResult Create()
        {
            // 등록 폼 출력

            return View();
        }

        // 등록 페이지에서 넘겨온 데이터 저장
        [HttpPost]
        public ActionResult CreateProcess(string title)
        {
            // 등록 처리: DB에 저장
            _repository.AddTask(new TaskModel { Title = title });

            return RedirectToAction("Index"); // 리스트로 이동
        }

        // 할 일 체크
        public ActionResult Complete(int id)
        {
            // 할 일 삭제 또는 체크 업데이트
            _repository.CompleteTask(id);

            return RedirectToAction("Index");
        }
    }
}
