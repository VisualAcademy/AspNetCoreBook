using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MemoEngine.Areas.Chatting.Controllers
{
    public class SimpleChatController : Controller
    {
        // GET: Chatting/SimpleChat
        public ActionResult Index()
        {



            return View();
        }

        // GET: Chatting/SimpleChat/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Chatting/SimpleChat/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Chatting/SimpleChat/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Chatting/SimpleChat/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Chatting/SimpleChat/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Chatting/SimpleChat/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Chatting/SimpleChat/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
