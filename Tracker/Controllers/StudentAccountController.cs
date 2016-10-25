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
        StudentManager studentManager = new StudentManager();

        // GET: StudentAccount
        [AllowAnonymous]
        [HttpGet]
        public ActionResult SignUp()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult SignUp(StudentViewModel student)
        {
            //if (ModelState.IsValid)
            {
                if (!studentManager.IsEmailExisting(student.email))
                {
                    studentManager.AddUserAccount(student);
                    FormsAuthentication.SetAuthCookie(student.email, false);
                    return RedirectToAction("Welcome", "StudentHome");
                }
                else
                    ModelState.AddModelError("", "Login Name already taken.");
            }
            return View();
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult LogIn()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult LogIn(StudentLoginView StudentLoginView)
        {
            if (ModelState.IsValid)
            {
                string password = studentManager.GetUserPassword(StudentLoginView.email);

                if (string.IsNullOrEmpty(password))
                    ModelState.AddModelError("", "The user login or password provided is incorrect.");
                else
                {
                    if (StudentLoginView.password.Equals(password))
                    {
                        FormsAuthentication.SetAuthCookie(StudentLoginView.email, false);
                        string role = studentManager.GetUserRole(StudentLoginView.email);
                        if (role == "admin")
                        {
                            return RedirectToAction("WelcomeAdmin", "StudentHome");
                        }
                        else if (role == "student")
                        {
                            return RedirectToAction("Welcome", "StudentHome");
                        }
                        else
                            return RedirectToAction("Unauthorised", "StudentHome");
                    }
                    else
                        ModelState.AddModelError("", "The password provided is incorrect.");
                }
            }
            return View();
        }

        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "StudentHome");
        }
    }
}