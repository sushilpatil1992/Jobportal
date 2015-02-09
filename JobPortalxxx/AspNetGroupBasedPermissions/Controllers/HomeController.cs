using AspNetGroupBasedPermissions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using JobPortalBVCOEK.BLL;

namespace AspNetGroupBasedPermissions.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        private JobService _jobService;
        public HomeController(JobService jobService)
        {
            _jobService = jobService;
        }

        public ActionResult Index()
        {
            var allJobs = _jobService.GetAllJobs();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult SearchJob(string companyName,string location,string language)
        {
           
            
            var companyLst = new List<string>();
            var companyQry = from d in db.Jobposts
                           orderby d.Company_Name
                             select d.Company_Name;
            companyLst.AddRange(companyQry.Distinct());
            ViewBag.companyName = new SelectList(companyLst);

            var locationLst = new List<string>();
            var locationQry = from d in db.Jobposts
                             orderby d.JobLocation
                             select d.JobLocation;
            locationLst.AddRange(locationQry.Distinct());
            ViewBag.location = new SelectList(locationLst);
            
            var jobpost = from j in db.Jobposts select j;
             if (!String.IsNullOrEmpty(language)) 
            { 
                jobpost = jobpost.Where(s => s.JobTitle.Contains(language)); 
            }

             if (!String.IsNullOrEmpty(companyName))
             {
                 jobpost = jobpost.Where(c => c.Company_Name==companyName);
             }

             
             if (!String.IsNullOrEmpty(location))
             {
                 jobpost = jobpost.Where(c => c.JobLocation==location);
             } 

            return View(jobpost);
        }

        public ActionResult Details(int? id)
        {
            if (User.IsInRole("Jobseeker"))
            {
                var userId = User.Identity.GetUserId();
                var profileId = db.Profiles.Where(c => c.ApplicationUserId == userId).First().UserId;
                var Username = db.Profiles.Where(c => c.ApplicationUserId == userId).First().Name;
                bool exist = db.Job_Applied.Any(c => c.Seeker_Id == profileId && c.Jobpost_id == id);
                bool expired=db.Jobposts.Any(c=>c.JobPostExpDate<DateTime.Now);
                if (exist)
                {
                    TempData["Message"] = "You Have Aleredy Applied";

                }
                
                ViewBag.Message = TempData["Message"] as string;
            }
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewBag.JobId = id;
            Jobpost jobpost = db.Jobposts.Find(id);
            if (jobpost == null)
            {
                return HttpNotFound();
            }
            return View(jobpost);
        }

        public ActionResult InterviewTips()
        {
            return View();
        }

        public ActionResult Apply(int id)
        {
            
             
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var userId = User.Identity.GetUserId();
            var profileId = db.Profiles.Where(c => c.ApplicationUserId == userId).First().UserId;
            var Username = db.Profiles.Where(c => c.ApplicationUserId == userId).First().Name;
            bool exist = db.Job_Applied.Any(c => c.Seeker_Id == profileId && c.Jobpost_id==id);
            if(exist)
            {
                TempData["Message"] = "You Have Aleredy Applied";
                
            }
           
            job_applied a = new job_applied
            {
                Seeker_Id = profileId,
                Jobpost_id=id,
                Name=Username,
            };
            db.Job_Applied.Add(a);
            db.SaveChanges();

            return RedirectToAction("SearchJob");
        }

        public ActionResult Notification()
        {
            var userId = User.Identity.GetUserId();
            var profileId = db.Profiles.Where(c => c.ApplicationUserId == userId).First().UserId;
            var from = db.Notifications.Where(c => c.to == profileId).First().from;
            var cmpnyname = db.EmpProfiles.Where(c => c.UserId == from).First().Company;
            ViewBag.Name=cmpnyname;
            Notification notification =db.Notifications.Where(c => c.to == profileId).First();
            return View(notification);
        }

    }
}