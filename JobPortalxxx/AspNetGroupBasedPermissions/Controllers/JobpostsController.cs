using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AspNetGroupBasedPermissions.Models;
using Microsoft.AspNet.Identity;
using JobPortalBVCOEK.BLL;

namespace AspNetGroupBasedPermissions.Controllers
{
    public class JobpostsController : Controller
    {
        private JobService _jobService;

        public JobpostsController(JobService jobService)
        {
            _jobService = jobService;
        }

        private ApplicationDbContext db = new ApplicationDbContext();
        
        // GET: Jobposts
        public ActionResult Index()
        {
            
            var userId = User.Identity.GetUserId();
            var profileId = db.EmpProfiles.Where(c => c.ApplicationUserId == userId).First().UserId;
            ViewBag.ProfileId = profileId;
            return View(db.Jobposts.ToList().Where(p => p.ProfileId==profileId));
        }

        // GET: Jobposts/Details/5
        public ActionResult Details(int? id)
        {
            
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jobpost jobpost = db.Jobposts.Find(id);
            if (jobpost == null)
            {
                return HttpNotFound();
            }
            return View(jobpost);
        }

        // GET: Jobposts/Create
        public ActionResult Create(int ProfileId)
        {
            var userId = User.Identity.GetUserId();
            var company=db.EmpProfiles.Where(c => c.ApplicationUserId == userId).First().Company;
            var mobile = db.EmpProfiles.Where(c => c.ApplicationUserId == userId).First().MobNo;
            var contact = db.EmpProfiles.Where(c => c.ApplicationUserId == userId).First().Name;
            var industry = db.EmpProfiles.Where(c => c.ApplicationUserId == userId).First().Industry;
            var CmpnyProfile = db.EmpProfiles.Where(c => c.ApplicationUserId == userId).First().company_profile;
            
            ViewBag.Company = company;
            ViewBag.Contact = contact;
            ViewBag.Industry = industry;
            ViewBag.Mobile = mobile;
            ViewBag.CompanyProfile = CmpnyProfile;
            
            return View();
        }

        // POST: Jobposts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,JobTitle,JobDiscription,MinExperince,MaxExperince,MinSal,MaxSal,Vacancy,JobLocation,Industry,Company_Name,ContactPerson,Mobile,JobPostDate,JobPostExpDate,ProfileId,company_profile ")] Jobpost jobpost)
        {
            if (ModelState.IsValid)
            {
                jobpost.JobPostDate = DateTime.Now;
                db.Jobposts.Add(jobpost);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(jobpost);
        }

        // GET: Jobposts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jobpost jobpost = db.Jobposts.Find(id);
            if (jobpost == null)
            {
                return HttpNotFound();
            }
            return View(jobpost);
        }

        // POST: Jobposts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,JobTitle,JobDiscription,MinExperince,MaxExperince,MinSal,MaxSal,Vacancy,JobLocation,Industry,Company_Name,ContactPerson,Mobile,JobPostDate,JobPostExpDate,company_profile")] Jobpost jobpost)
        {
            if (ModelState.IsValid)
            {
                var userId = User.Identity.GetUserId();
                jobpost.ProfileId = db.EmpProfiles.Where(c => c.ApplicationUserId == userId).First().UserId;
                db.Entry(jobpost).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(jobpost);
        }

        // GET: Jobposts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jobpost jobpost = db.Jobposts.Find(id);
            if (jobpost == null)
            {
                return HttpNotFound();
            }
            return View(jobpost);
        }

        // POST: Jobposts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Jobpost jobpost = db.Jobposts.Find(id);
            db.Jobposts.Remove(jobpost);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

       public ActionResult AppliedForJob(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
           
           
            return View(db.Job_Applied.ToList().Where(p => p.Jobpost_id == id));
            
        }

       public ActionResult EmployeeProfile()
       {
           var userId = User.Identity.GetUserId();
           var profileId = db.EmpProfiles.Where(c => c.ApplicationUserId == userId).First().UserId;
           ViewBag.ProfileId = profileId;
           EmpProfile Profile = db.EmpProfiles.Find(profileId);
           return View(Profile);
       }

       public ActionResult EditEmpProfile(int? id)
       {
           if (id == null)
           {
               return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
           }
           var userId = User.Identity.GetUserId();
           var profileuserId=db.EmpProfiles.Where(c => c.ApplicationUserId == userId).First().UserId;
           if (profileuserId == id)
           {
               EmpProfile Profile = db.EmpProfiles.Find(id);

               if (Profile == null)
               {
                   return HttpNotFound();
               }
               return View(Profile);
           }
           return new HttpStatusCodeResult(HttpStatusCode.NotFound);
       }

       [HttpPost]
       [ValidateAntiForgeryToken]
       public ActionResult EditEmpProfile(EmpProfile EmpProfile)
       {
           if (ModelState.IsValid)
           {
               var userId = User.Identity.GetUserId();
               EmpProfile.ApplicationUserId = userId;
               db.Entry(EmpProfile).State = EntityState.Modified;
               db.SaveChanges();
               return RedirectToAction("EmployeeProfile");
           }
           return View(EmpProfile);
       }
        
        
        public ActionResult JobseekerProfile (int? id)
       {
           var profileId = db.Job_Applied.Where(c => c.Id == id).First().Seeker_Id;
           Profile profile = db.Profiles.Find(profileId);
           if (profile == null)
           {
               return HttpNotFound();
           }
           return View(profile);
       }

        public ActionResult SendMessage(int id)
        {
            var jobseekerId = db.Job_Applied.Where(c => c.Id == id).First().Seeker_Id;
            var name = db.Job_Applied.Where(c => c.Id == id).First().Name;
            ViewBag.To = jobseekerId;
            ViewBag.Name = name;
            return View();
        }
        [HttpPost]
        public ActionResult SendMessage(Notification notification)
        {
            if (ModelState.IsValid)
            {
                var userId = User.Identity.GetUserId();
                var EmpProfileId = db.EmpProfiles.Where(c => c.ApplicationUserId == userId).First().UserId;
                notification.from = EmpProfileId;                
                db.Notifications.Add(notification);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();

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
