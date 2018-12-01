﻿using DotNetNote.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotNetNote.Controllers
{
    public class FormValidationDemoController : Controller
    {
        //[1] 따라하기 1: 폼 유효성 검사 테스트용 메인 페이지 작성 
        #region Main Page
        public IActionResult Index()
        {
            return View();
        } 
        #endregion



        //[2] 따라하기 2: 순수 HTML과 JavaScript를 사용한 유효성 검사 
        #region HTML
        public IActionResult Html()
        {
            return View();
        }

        // [HttpPost]
        public IActionResult HtmlProcess(string txtName, string txtContent)
        {
            //var r = $"이름: {txtName}, 내용: {txtContent}";
            ViewBag.ResultString = 
                $"이름: {txtName}, 내용: {Request.Form["txtContent"]}";
            return View();
        }
        #endregion



        //[3] 따라하기 3: MVC 헬퍼 메서드 사용하기
        #region Helper Method
        [HttpGet]
        public IActionResult HelperMethod()
        {
            return View();
        }

        [HttpPost]
        public IActionResult HelperMethod(string txtName, string txtContent)
        {
            ViewBag.ResultString = $"이름: {txtName}, 내용: {txtContent}";
            return View();
        }
        #endregion



        //[4] 따라하기 4: 강력한 형식의 뷰와 모델 바인딩 사용하기
        #region Strongly Type View + Model Binding
        public IActionResult StronglyTypeView()
        {
            return View();
        }

        [HttpPost]
        public IActionResult StronglyTypeView(MaximModel model)
        {
            return View();
        }
        #endregion



        //[5] 따라하기 5: 모델 기반 유효성 검사 및 서버측 유효성 검사
        #region Model Validation + Server Validation
        public IActionResult ModelValidation()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ModelValidation(MaximModel model)
        {
            // 직접 유효성 검사
            if (string.IsNullOrEmpty(model.Name))
            {
                ModelState.AddModelError("Name", "이름을 입력하세요.");
            }
            if (string.IsNullOrEmpty(model.Content))
            {
                ModelState.AddModelError("Content", "내용을 입력하세요.");
            }

            if (!ModelState.IsValid)
            {
                // @Html.ValidationSummary(true)일 때는 아래 에러만 표시
                ModelState.AddModelError("", "모든 에러");
            }

            // 넘겨온 모델에 대한 유효성 검사
            if (ModelState.IsValid)
            {
                return View("Completed");
            }

            return View();
        }

        public IActionResult Completed()
        {
            return View();
        }
        #endregion



        //[6] 따라하기 6: 클라이언트측 유효성 검사
        #region Client Validation
        public IActionResult ClientValidation()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ClientValidation(MaximModel model)
        {
            // 넘겨온 모델에 대한 유효성 검사
            if (ModelState.IsValid)
            {
                return View("Completed");
            }

            return View();
        }
        #endregion



        //[7] 따라하기 7: 태그 헬퍼 사용하기
        #region TagHelper
        public IActionResult TagHelperValidation()
        {
            return View();
        }

        [HttpPost]
        public IActionResult TagHelperValidation(MaximModel model)
        {
            // 넘겨온 모델에 대한 유효성 검사
            if (ModelState.IsValid)
            {
                return View("Completed");
            }

            return View();
        }
        #endregion
    }
}
