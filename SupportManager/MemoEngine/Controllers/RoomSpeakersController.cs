using MemoEngine.Models;
using System.Data.Entity;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MemoEngine.Controllers
{
    public class RoomSpeakersController : Controller
    {
        private ConfContext db = new ConfContext();

        // GET: RoomSpeakers
        public async Task<ActionResult> Index()
        {
            var roomSpeakers = db.RoomSpeakers.Include(r => r.Room);
            return View(await roomSpeakers.ToListAsync());
        }

        // GET: RoomSpeakers/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoomSpeaker roomSpeaker = await db.RoomSpeakers.FindAsync(id);
            if (roomSpeaker == null)
            {
                return HttpNotFound();
            }
            return View(roomSpeaker);
        }

        // GET: RoomSpeakers/Create
        public ActionResult Create()
        {
            ViewBag.RoomId = new SelectList(db.Rooms, "RoomId", "Name");
            return View();
        }

        // POST: RoomSpeakers/Create
        // 초과 게시 공격으로부터 보호하려면 바인딩하려는 특정 속성을 사용하도록 설정하십시오. 
        // 자세한 내용은 http://go.microsoft.com/fwlink/?LinkId=317598을(를) 참조하십시오.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "RoomSpeakerId,Name,RoomId")] RoomSpeaker roomSpeaker)
        {
            if (ModelState.IsValid)
            {
                db.RoomSpeakers.Add(roomSpeaker);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.RoomId = new SelectList(db.Rooms, "RoomId", "Name", roomSpeaker.RoomId);
            return View(roomSpeaker);
        }

        // GET: RoomSpeakers/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoomSpeaker roomSpeaker = await db.RoomSpeakers.FindAsync(id);
            if (roomSpeaker == null)
            {
                return HttpNotFound();
            }
            ViewBag.RoomId = new SelectList(db.Rooms, "RoomId", "Name", roomSpeaker.RoomId);
            return View(roomSpeaker);
        }

        // POST: RoomSpeakers/Edit/5
        // 초과 게시 공격으로부터 보호하려면 바인딩하려는 특정 속성을 사용하도록 설정하십시오. 
        // 자세한 내용은 http://go.microsoft.com/fwlink/?LinkId=317598을(를) 참조하십시오.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "RoomSpeakerId,Name,RoomId")] RoomSpeaker roomSpeaker)
        {
            if (ModelState.IsValid)
            {
                db.Entry(roomSpeaker).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.RoomId = new SelectList(db.Rooms, "RoomId", "Name", roomSpeaker.RoomId);
            return View(roomSpeaker);
        }

        // GET: RoomSpeakers/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoomSpeaker roomSpeaker = await db.RoomSpeakers.FindAsync(id);
            if (roomSpeaker == null)
            {
                return HttpNotFound();
            }
            return View(roomSpeaker);
        }

        // POST: RoomSpeakers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            RoomSpeaker roomSpeaker = await db.RoomSpeakers.FindAsync(id);
            db.RoomSpeakers.Remove(roomSpeaker);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
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
