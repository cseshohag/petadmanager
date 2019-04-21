using PetApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace PetApplication.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        //public ActionResult Index()
        //{
        //    ViewBag.Current = "Home";
        //    return View();
        //}

        [HttpGet]
        public ActionResult Index(int? pageNumber)
        {
            ViewBag.Current = "Home";
            return View(db.PetPost.ToList().ToPagedList(pageNumber ?? 1,5));
        }

        public ActionResult About()
        {
            ViewBag.Current = "About";
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Current = "Contact";
            ViewBag.Message = "Your contact page.";

            return View();
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
    }
}