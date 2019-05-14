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
        public ActionResult Index(string searchBy,string search,int? pageNumber)
        {
            ViewBag.Current = "Home";
            if(searchBy=="Price")
                return View(db.PetAnimal.Where(x => x.Price.StartsWith(search) || search==null).ToList().ToPagedList(pageNumber ?? 1,6));
            else if(searchBy == "Division")
                return View(db.PetAnimal.Where(x => x.Division.StartsWith(search) || search == null).ToList().ToPagedList(pageNumber ?? 1, 6));
            else if (searchBy == "Type")
                return View(db.PetAnimal.Where(x => x.PetType.PetTypeName.StartsWith(search) || search == null).ToList().ToPagedList(pageNumber ?? 1, 6));
            else if (searchBy == "Name")
                return View(db.PetAnimal.Where(x => x.Name.StartsWith(search) || search == null).ToList().ToPagedList(pageNumber ?? 1, 6));
            else if (searchBy == "Color")
                return View(db.PetAnimal.Where(x => x.Color.StartsWith(search) || search == null).ToList().ToPagedList(pageNumber ?? 1, 6));
            else if (searchBy == "Area")
                return View(db.PetAnimal.Where(x => x.Area.StartsWith(search) || search == null).ToList().ToPagedList(pageNumber ?? 1, 6));
            else if (searchBy == "Age")
                return View(db.PetAnimal.Where(x => x.Age.StartsWith(search) || search == null).ToList().ToPagedList(pageNumber ?? 1, 6));
            else
                return View(db.PetAnimal.Where(x => x.City.StartsWith(search) || search == null).ToList().ToPagedList(pageNumber ?? 1, 6));
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