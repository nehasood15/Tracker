using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tracker.Models.EntityManager;
using Tracker.Security;

namespace Tracker.Controllers
{
    public class StudentHomeController : Controller
    {
        //GET: StudentHome
        public ActionResult Index()
        {
            return View();
        }
       [AuthorizeRole("student")]
        public ActionResult Welcome()
        {
            StudentManager studentManager = new StudentManager();
            string proficiencyLevel = studentManager.GetUserProficiencyLevel(User.Identity.Name);
            if (proficiencyLevel.Trim() == "Not Selected")
            {
                return RedirectToAction("FillAnswers2", "StudentResponse");
            }
            return RedirectToAction("Index", "Resources");
        }

        [AuthorizeRole("admin")]
        public ActionResult WelcomeAdmin()
        {
            return View();
        }
        public ActionResult Unauthorised()
        {
            return View();
        }
    }
}