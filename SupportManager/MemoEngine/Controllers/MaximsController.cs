using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MemoEngine.Models;

namespace MemoEngine.Controllers
{
    public class MaximsController : Controller
    {
        private MaximsContext db = new MaximsContext();

        // GET: Maxims
        public ActionResult Index()
        {
            return View(db.Maxims.ToList());
        }

        // GET: Maxims/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Maxim maxim = db.Maxims.Find(id);
            if (maxim == null)
            {
                return HttpNotFound();
            }
            return View(maxim);
        }

        // GET: Maxims/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Maxims/Create
        // 초과 게시 공격으로부터 보호하려면 바인딩하려는 특정 속성을 사용하도록 설정하십시오. 
        // 자세한 내용은 http://go.microsoft.com/fwlink/?LinkId=317598을(를) 참조하십시오.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Content")] Maxim maxim)
        {
            if (ModelState.IsValid)
            {

                maxim.CreationDate = DateTime.Now; // # 날짜 추가

                db.Maxims.Add(maxim);
                db.SaveChanges();
                return RedirectToAction("Index", "Maxims");
            }

            return View(maxim);
        }

        // GET: Maxims/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Maxim maxim = db.Maxims.Find(id);
            if (maxim == null)
            {
                return HttpNotFound();
            }
            return View(maxim);
        }

        // POST: Maxims/Edit/5
        // 초과 게시 공격으로부터 보호하려면 바인딩하려는 특정 속성을 사용하도록 설정하십시오. 
        // 자세한 내용은 http://go.microsoft.com/fwlink/?LinkId=317598을(를) 참조하십시오.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Content")] Maxim maxim)
        {
            if (ModelState.IsValid)
            {
                db.Entry(maxim).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Maxims");
            }
            return View(maxim);
        }

        // GET: Maxims/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Maxim maxim = db.Maxims.Find(id);
            if (maxim == null)
            {
                return HttpNotFound();
            }
            return View(maxim);
        }

        // POST: Maxims/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Maxim maxim = db.Maxims.Find(id);
            db.Maxims.Remove(maxim);
            db.SaveChanges();
            return RedirectToAction("Index", "Maxims");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
