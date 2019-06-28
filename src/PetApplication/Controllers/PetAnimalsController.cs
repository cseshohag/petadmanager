using System;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PetApplication.Models;
using System.IO;
using System.Net.Mail;
using System.Web.Security;
using Microsoft.AspNet.Identity;
using System.Linq;
using PusherServer;

namespace PetApplication.Controllers
{
    public class PetAnimalsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PetAnimals
        
        //[AllowAnonymous]
        [Authorize]
        public async Task<ActionResult> Index()
        {
            PetAnimal petAnimals = new PetAnimal();
            ViewBag.Current = "PetAnimals";
            //if (User.Identity.GetUserId() == petAnimals.CreateBy)
            //{
            //    var petAnimal = db.PetAnimal.Include(p => p.PetType);
            //    return View(await petAnimal.ToListAsync());
            //    //return View(db.PetAnimal.Where(x => x.CreateBy.Equals(User.Identity.GetUserId())).ToList());
            //}
            //return View();
            var getUserID = User.Identity.GetUserId();
            var adminID = "6123524f-662d-4677-8836-5c95da5e52c8";
            var petAnimal = db.PetAnimal.Include(p => p.PetType);
            if(getUserID.Equals(adminID))
                return View(await petAnimal.ToListAsync());
            return View(await petAnimal.Where(x => x.CreateBy.Equals(getUserID)).ToListAsync());
        }

        // GET: PetAnimals/Details/5
        [AllowAnonymous]
        public async Task<ActionResult> Details(int? id)
        {
            ViewBag.Current = "PetAnimals";
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PetAnimal petAnimal = await db.PetAnimal.FindAsync(id);
            if (petAnimal == null)
            {
                return HttpNotFound();
            }
            return View(petAnimal);
        }

        // GET: PetAnimals/Create
        [Authorize]
        public ActionResult Create()
        {
            ViewBag.Current = "PetAnimals";
            ViewBag.PetTypeID = new SelectList(db.PetType, "PetTypeID", "PetTypeName");
            return View();
        }

        // POST: PetAnimals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,ShortCode,Age,Color,ImageUrl,Quantity,Details,Price,PhoneNumber,Email,IsSold,Area,City,Division,PetTypeID,PetTypeName,CreateBy,CreateDate")] PetAnimal petAnimal, HttpPostedFileBase file)
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
                        petAnimal.ImageUrl = @"~/" + @"Images/PetImage" + @"/" + fileName;
                    }
                    petAnimal.CreateBy = User.Identity.GetUserId();
                    ViewBag.FileStatus = "File uploaded successfully.";
                    petAnimal.CreateDate = DateTime.Now;
                    petAnimal.ShortCode = "Pet" + Guid.NewGuid().ToString();
                    db.PetAnimal.Add(petAnimal);
                    await db.SaveChangesAsync();
                }
                catch (Exception)
                {

                    ViewBag.FileStatus = "Error while file uploading.";
                }


                //db.PetAnimal.Add(petAnimal);
                //await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.PetTypeID = new SelectList(db.PetType, "PetTypeID", "PetTypeName", petAnimal.PetTypeID);
            return View(petAnimal);
        }

        // GET: PetAnimals/Edit/5
        [Authorize]
        public async Task<ActionResult> Edit(int? id)
        {
            ViewBag.Current = "PetAnimals";
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PetAnimal petAnimal = await db.PetAnimal.FindAsync(id);
            if (petAnimal == null)
            {
                return HttpNotFound();
            }
            ViewBag.PetTypeID = new SelectList(db.PetType, "PetTypeID", "PetTypeName", petAnimal.PetTypeID);
            return View(petAnimal);
        }

        // POST: PetAnimals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,ShortCode,Age,Color,ImageUrl,Quantity,Details,Price,PhoneNumber,Email,IsSold,Area,City,Division,PetTypeID,PetTypeName,CreateBy,CreateDate")] PetAnimal petAnimal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(petAnimal).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.PetTypeID = new SelectList(db.PetType, "PetTypeID", "PetTypeName", petAnimal.PetTypeID);
            return View(petAnimal);
        }

        // GET: PetAnimals/Delete/5
        [Authorize]
        public async Task<ActionResult> Delete(int? id)
        {
            ViewBag.Current = "PetAnimals";
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PetAnimal petAnimal = await db.PetAnimal.FindAsync(id);
            if (petAnimal == null)
            {
                return HttpNotFound();
            }
            return View(petAnimal);
        }

        // POST: PetAnimals/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            PetAnimal petAnimal = await db.PetAnimal.FindAsync(id);
            db.PetAnimal.Remove(petAnimal);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        
        public void SendEmail()
        {
            MailMessage mail = new MailMessage("wdxshohag@gmail.com", "sendTo", "mailSubject", "mailBody");
            mail.From = new MailAddress("solaiman.shohag95@gmail.com", "nameEmail");
            mail.IsBodyHtml = true; // necessary if you're using html email

            NetworkCredential credential = new NetworkCredential("xxx@gmail.com", "xxxxx");
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = credential;
            smtp.Send(mail);
        }

        public ActionResult Comments(int? id)
        {
            var comments = db.Comment.Where(x => x.PetAnimal.Id == id).ToArray();
            return Json(comments, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public async Task<ActionResult> Comment(Comment data)
        {
            db.Comment.Add(data);
            db.SaveChanges();
            var options = new PusherOptions();
            options.Cluster = "ap1";
            var pusher = new Pusher("810929", "093c221464e0b9370411", "ddfeb0fbf4c35863680d", options);
            ITriggerResult result = await pusher.TriggerAsync("asp_channel", "asp_event", data);
            return Content("ok");
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
