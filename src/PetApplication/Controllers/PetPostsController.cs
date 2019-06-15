using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PetApplication.Models;
using System.IO;
using System.Web.Hosting;

namespace PetApplication.Controllers
{
    public class PetPostsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private readonly HostingEnvironment _appEnvironment;

               
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.Current = "PetPosts";
            return View(db.PetPost.ToList());
        }


        [HttpGet]
        public ActionResult GetPetImages()
        {
            ViewBag.PetImages = db.PetPost.ToList();
            return View("~/Views/Home/Index.cshtml", ViewBag.PetImages);
        }
        // GET: PetPosts/Details/5
        [HttpGet]
        public ActionResult Details(int? id)
        {
            ViewBag.Current = "PetPosts";
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PetPost petPost = db.PetPost.Find(id);
            if (petPost == null)
            {
                return HttpNotFound();
            }
            return View(petPost);
        }

        //[HttpGet]
        //public ActionResult Report()
        //{
        //    return View();
        //}


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Report([Bind(Include = "PostReportID, PetPostID, Report")] PostReport postReport)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.PostReport.Add(postReport);
        //        db.SaveChanges();
        //        //return RedirectToAction("Index");
        //    }
        //    return View();
        //}

        // GET: PetPosts/Create
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Current = "PetPosts";
            List<Pet> petList = db.Pet.ToList();
            ViewBag.PetList = new SelectList(petList, "PetID", "PetName");
            return View();
        }

        // POST: PetPosts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PetPostID,PetID,PetPrice,PetDetails,PetImageUrl,PetLocation,PostCreatedDat,PetColor,PostStatus")] PetPost petPost, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    String fileName = "";                    
                    if (file != null)
                    {
                        fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                        string physicalPath = Server.MapPath("~/Images/PetImage/" + fileName);                        
                        file.SaveAs(physicalPath);                        
                        petPost.PetImageUrl = @"~/" + @"Images/PetImage" + @"/" + fileName;
                    }

                    ViewBag.FileStatus = "File uploaded successfully.";
                    petPost.PostCreatedDate = DateTime.Now;
                    db.PetPost.Add(petPost);
                    db.SaveChanges();
                }
                catch (Exception)
                {

                    ViewBag.FileStatus = "Error while file uploading.";
                }                                
                return RedirectToAction("Index");
            }

            return View(petPost);
        }



        // GET: PetPosts/Edit/5
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            ViewBag.Current = "PetPosts";
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PetPost petPost = db.PetPost.Find(id);
            if (petPost == null)
            {
                return HttpNotFound();
            }
            List<Pet> petList = db.Pet.ToList();
            ViewBag.PetList = new SelectList(petList, "PetID", "PetName");
            return View(petPost);
        }

        // POST: PetPosts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PetPostID,PetID,PetPrice,PetDetails,PetImageUrl,PetLocation,PostCreatedDate,PetColor,PostStatus")] PetPost petPost, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                String fileName = "";
                if (file != null)
                {
                    fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string physicalPath = Server.MapPath("~/Images/PetImage/" + fileName);
                    file.SaveAs(physicalPath);
                    petPost.PetImageUrl = @"~/" + @"Images/PetImage" + @"/" + fileName;
                }

                petPost.PostCreatedDate = DateTime.Now;
                db.Entry(petPost).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(petPost);
        }

        // GET: PetPosts/Delete/5
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            ViewBag.Current = "PetPosts";
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PetPost petPost = db.PetPost.Find(id);
            if (petPost == null)
            {
                return HttpNotFound();
            }
            return View(petPost);
        }

        // POST: PetPosts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ViewBag.Current = "PetPosts";
            PetPost petPost = db.PetPost.Find(id);
            db.PetPost.Remove(petPost);
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
