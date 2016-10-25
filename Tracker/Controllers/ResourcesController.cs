using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Tracker.Models.ViewModels;
using Tracker.Models.EntityManager;
using Tracker.Models.DB;
using Tracker.Security;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web.Services.Description;

namespace Tracker.Controllers
{
    public class ResourcesController : Controller
    {
        // GET: Resources
        [HttpGet]
        [AuthorizeRole("student")]
        public ActionResult Index()
        {
            ResourceManager ResourceManager = new ResourceManager();
            StudentManager studentManager = new StudentManager();
            string proficiencyLevel = studentManager.GetUserProficiencyLevel(User.Identity.Name);
            //To-do: Make proficiency level as an enum

            return View(ResourceManager.GetResourcesBasedOnProficiencyLevel(1));
        }

        [HttpGet]
        [AuthorizeRole("admin","student")]
        public ActionResult AllResources()
        {
            ResourceManager ResourceManager = new ResourceManager();
            //To-do: Make proficiency level as an enum
            return View(ResourceManager.GetAllResources().OrderByDescending(model => model.proficiencyId));
        }

        [HttpGet]
        [AuthorizeRole("admin")]
        public ActionResult AddNewResource()
        {
            ResourceManager ResourceManager = new ResourceManager();

            return View();
        }

        [HttpPost]
        [AuthorizeRole("admin")]
        public ActionResult AddNewResource(ResourceViewModel resourceModel)
        {
            if (ModelState.IsValid)
            {
                ResourceManager ResourceManager = new ResourceManager();
                ResourceManager.AddNewResource(resourceModel);
                Email(resourceModel);
               
               return RedirectToAction("AllResources", "Resources");
            }
            else
                ModelState.AddModelError("", "Error Adding Resource. Please fill all mandatory fields and Try Again");
            return View();
        }

        public void Email(ResourceViewModel resourceModel)
        {
            // To-do  Ask dom--> If email should be as per resource proficiency level?????( i.e watever proficeincy resource added, email only to those students who have that proficiency)
            StudentTrackerEntities db = new StudentTrackerEntities();
            List<Student> students = db.Students.ToList();

            //var body = "<p>Email From: {0} ({1})</p><p>Message:</p><p>{2}</p>";
            var body = "<p>Hi!</p><p>New Tutorial Added:</p><p><b>Name:</b>{0}></br><b> Link:</b><a href = \"{1}\">Click Here</a></p><p>All the Best!</p>";
            var message = new MailMessage();
            foreach (Student student in students)
            {
                message.Bcc.Add(new MailAddress(student.email.Trim()));
            }
            message.Subject = "New Tutorial Added";
            message.Body = string.Format(body, resourceModel.resourceName , resourceModel.resourceLink);
            message.IsBodyHtml = true;
            using (var smtp = new SmtpClient())
            {
                 smtp.Send(message);
            }
        }
    }
}