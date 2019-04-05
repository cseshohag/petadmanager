using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PetApplication.Models;

namespace PetApplication.Controllers
{
    public class PetAnimalsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PetAnimals
        public async Task<ActionResult> Index()
        {
            var petAnimals = db.PetAnimals.Include(p => p.PetType);
            return View(await petAnimals.ToListAsync());
        }

        // GET: PetAnimals/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PetAnimal petAnimal = await db.PetAnimals.FindAsync(id);
            if (petAnimal == null)
            {
                return HttpNotFound();
            }
            return View(petAnimal);
        }

        // GET: PetAnimals/Create
        public ActionResult Create()
        {
            ViewBag.PetTypeID = new SelectList(db.PetTypes, "PetTypeID", "PetTypeName");
            return View();
        }

        // POST: PetAnimals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,ShortCode,Age,Color,ImageUrl,Quantity,Details,Price,PhoneNumber,Email,IsSold,Area,City,Division,PetTypeID,PetTypeName,CreateBy,CreateDate")] PetAnimal petAnimal)
        {
            if (ModelState.IsValid)
            {
                db.PetAnimals.Add(petAnimal);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.PetTypeID = new SelectList(db.PetTypes, "PetTypeID", "PetTypeName", petAnimal.PetTypeID);
            return View(petAnimal);
        }

        // GET: PetAnimals/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PetAnimal petAnimal = await db.PetAnimals.FindAsync(id);
            if (petAnimal == null)
            {
                return HttpNotFound();
            }
            ViewBag.PetTypeID = new SelectList(db.PetTypes, "PetTypeID", "PetTypeName", petAnimal.PetTypeID);
            return View(petAnimal);
        }

        // POST: PetAnimals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,ShortCode,Age,Color,ImageUrl,Quantity,Details,Price,PhoneNumber,Email,IsSold,Area,City,Division,PetTypeID,PetTypeName,CreateBy,CreateDate")] PetAnimal petAnimal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(petAnimal).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.PetTypeID = new SelectList(db.PetTypes, "PetTypeID", "PetTypeName", petAnimal.PetTypeID);
            return View(petAnimal);
        }

        // GET: PetAnimals/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PetAnimal petAnimal = await db.PetAnimals.FindAsync(id);
            if (petAnimal == null)
            {
                return HttpNotFound();
            }
            return View(petAnimal);
        }

        // POST: PetAnimals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            PetAnimal petAnimal = await db.PetAnimals.FindAsync(id);
            db.PetAnimals.Remove(petAnimal);
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
