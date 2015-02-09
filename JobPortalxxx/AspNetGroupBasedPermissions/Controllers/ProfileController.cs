using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using AspNetGroupBasedPermissions.Models;
using System.Net;
using System.Data.Entity;

namespace AspNetGroupBasedPermissions.Controllers
{
    public class ProfileController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Profile
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            var profileId = db.Profiles.Where(c => c.ApplicationUserId == userId).First().UserId;
            ViewBag.ProfileId = profileId;
            Profile Profile = db.Profiles.Find(profileId);
            return View(Profile);    
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profile Profile = db.Profiles.Find(id);
            if (Profile == null)
            {
                return HttpNotFound();
            }
            return View(Profile);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Profile profile)
        {
            if (ModelState.IsValid)
            {
                var userId = User.Identity.GetUserId();
                profile.ApplicationUserId = userId;
                db.Entry(profile).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(profile);
        }
    }
}