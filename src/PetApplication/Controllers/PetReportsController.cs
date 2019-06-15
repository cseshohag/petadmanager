using System.Data.Entity;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using PetApplication.Models;

namespace PetApplication.Controllers
{
    public class PetReportsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PetReports
        public async Task<ActionResult> Index()
        {
            var petReport = db.PetReport.Include(p => p.PetAminal);
            return View(await petReport.ToListAsync());
        }

        // GET: PetReports/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PetReport petReport = await db.PetReport.FindAsync(id);
            if (petReport == null)
            {
                return HttpNotFound();
            }
            return View(petReport);
        }

        // GET: PetReports/Create
        public ActionResult Create(int? id)
        {
            ViewBag.Id = new SelectList(db.PetAnimal, "Id", "Name");
            return View();
        }

        // POST: PetReports/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ReportID,Id,Report")] PetReport petReport)
        {
            if (ModelState.IsValid)
            {
                db.PetReport.Add(petReport);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.Id = new SelectList(db.PetAnimal, "Id", "Name", petReport.Id);
            return View(petReport);
        }

        // GET: PetReports/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PetReport petReport = await db.PetReport.FindAsync(id);
            if (petReport == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id = new SelectList(db.PetAnimal, "Id", "Name", petReport.Id);
            return View(petReport);
        }

        // POST: PetReports/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ReportID,Id,Report")] PetReport petReport)
        {
            if (ModelState.IsValid)
            {
                db.Entry(petReport).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Id = new SelectList(db.PetAnimal, "Id", "Name", petReport.Id);
            return View(petReport);
        }

        // GET: PetReports/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PetReport petReport = await db.PetReport.FindAsync(id);
            if (petReport == null)
            {
                return HttpNotFound();
            }
            return View(petReport);
        }

        // POST: PetReports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            PetReport petReport = await db.PetReport.FindAsync(id);
            db.PetReport.Remove(petReport);
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
