using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Tracker.Models.ViewModels;
using Tracker.Models.EntityManager;

namespace Tracker.Controllers
{
    public class StudentAccountController : Controller
    {
        // GET: StudentAccount
        //[AllowAnonymous]

        [HttpGet]
            public ActionResult SignUp()
            {
                return View();
            }

        //[AllowAnonymous]

        [HttpPost]
            public ActionResult SignUp(StudentModel student)
            {
                if (ModelState.IsValid)
                {
                    StudentManager StuManager = new StudentManager();
                    if (!StuManager.IsEmailExisting(student.email))
                    {
                        StuManager.AddUserAccount(student);
                        //FormsAuthentication.SetAuthCookie(student.firstName, false);
                        return RedirectToAction("Welcome", "StudentHome");

                    }
                    else
                        ModelState.AddModelError("", "Login Name already taken.");
                }
                return View();
            }

        //[AllowAnonymous]

        [HttpGet]
        public ActionResult LogIn()
        {
            return View();
        }

        //[Authorize]

        [HttpPost]
        public ActionResult LogIn(StudentLoginView StudentLoginView, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                StudentManager StudentManger = new StudentManager();
                string password = StudentManger.GetUserPassword(StudentLoginView.email);

                if (string.IsNullOrEmpty(password))
                    ModelState.AddModelError("", "The user login or password provided is incorrect.");
                else
                {
                    if (StudentLoginView.password.Equals(password))
                    {
                        //FormsAuthentication.SetAuthCookie(StudentLoginView.email, false);
                        return RedirectToAction("Welcome", "StudentHome");
                    }
                    else
                        return RedirectToAction("Welcome", "StudentHome");

                   // ModelState.AddModelError("", "The password provided is incorrect.");
                    
                }
            }

            return View(StudentLoginView);
        }

        public ActionResult SignOut()
        {
            //FormsAuthentication.SignOut();
            return RedirectToAction("Index", "StudentHome");
        }
    }
    }
  