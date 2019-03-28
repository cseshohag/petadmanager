using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PetApplication.Models;

namespace PetApplication.Controllers
{
    public class PostReportsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PostReports
        public ActionResult Index()
        {
            var postReport = db.PostReport.Include(p => p.PetPost);
            return View(postReport.ToList());
        }

        // GET: PostReports/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PostReport postReport = db.PostReport.Find(id);
            if (postReport == null)
            {
                return HttpNotFound();
            }
            return View(postReport);
        }

        // GET: PostReports/Create
        public ActionResult Create(int? id)
        {
            ViewBag.PetPostID = new SelectList(db.PetPost, "PetPostID", "PetDetails");
            //ViewBag.PetPostID = id;
            return View();
        }

        // POST: PostReports/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ReportID,PetPostID,Report")] PostReport postReport)
        {
            if (ModelState.IsValid)
            {
                db.PostReport.Add(postReport);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PetPostID = new SelectList(db.PetPost, "PetPostID", "PetDetails", postReport.PetPostID);
            return View(postReport);
        }

        // GET: PostReports/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PostReport postReport = db.PostReport.Find(id);
            if (postReport == null)
            {
                return HttpNotFound();
            }
            ViewBag.PetPostID = new SelectList(db.PetPost, "PetPostID", "PetDetails", postReport.PetPostID);
            return View(postReport);
        }

        // POST: PostReports/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ReportID,PetPostID,Report")] PostReport postReport)
        {
            if (ModelState.IsValid)
            {
                db.Entry(postReport).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PetPostID = new SelectList(db.PetPost, "PetPostID", "PetDetails", postReport.PetPostID);
            return View(postReport);
        }

        // GET: PostReports/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PostReport postReport = db.PostReport.Find(id);
            if (postReport == null)
            {
                return HttpNotFound();
            }
            return View(postReport);
        }

        // POST: PostReports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PostReport postReport = db.PostReport.Find(id);
            db.PostReport.Remove(postReport);
            db.SaveChanges();
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
