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

namespace Tracker.Controllers
{
    public class StudentResponseController : Controller
    {
        StudentTrackerEntities db = new StudentTrackerEntities();
        ResponseManager ResponseManager = new ResponseManager();

        // GET: StudentResponse
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult FillAnswers(List<StudentResponseViewModel> studentResponses)
        {
            ResponseManager ResponseManager = new ResponseManager();

            var questions = ResponseManager.GetAllQuestions();

            if (ModelState.IsValid)
            {                
               // ResponseManager ResponseManager = new ResponseManager();
                ResponseManager.AddStudentResponse(studentResponses);
                //FormsAuthentication.SetAuthCookie(student.firstName, false);
                return RedirectToAction("Welcome", "StudentHome");
            }
            return View(questions);
        }
        [HttpGet]
        public ActionResult FillAnswers2()
        {
            var model = new ListStudentResponsesViewModel()
            {
                AllQuestions = ResponseManager.GetAllQuestions(),
                StudentId = ResponseManager.GetAllStudents().First().studentId
            };
            return View(model);
        }

        [HttpPost]
        [AuthorizeRole("student")]
        //authorise this , and add it to student view after login, then see if get user if works with user.identity.name
        public ActionResult FillAnswers2(ListStudentResponsesViewModel studentResponses)
        {
            ResponseManager ResponseManager = new ResponseManager();
            StudentManager StudentManager = new StudentManager();

            studentResponses.StudentId = StudentManager.GetUserId(User.Identity.Name);
            int studentID = StudentManager.GetUserId(User.Identity.Name);
            int levelCount = 0;
            foreach (StudentResponse response in studentResponses.Responses)
            {
                response.studentId = studentID;
                //to-do: change level count logic and discuss with Dom , on how to decide proficiency.
                if(response.response == "Yes")
                {
                    levelCount++;
                }
            }
            
            if (ModelState.IsValid)
            {
                ResponseManager.AddStudentResponse2(studentResponses);
               int proficiencyLevel;
               if(levelCount <= 2)
                {
                    proficiencyLevel = 1;
                }
               else if (levelCount > 2 && levelCount <= 5 )
                {
                    proficiencyLevel = 2;

                }
                else
                {
                    proficiencyLevel = 3;
                }
                StudentManager.AddStudentProficiencyLevel(proficiencyLevel , studentID);
                //FormsAuthentication.SetAuthCookie(student.firstName, false);
                return RedirectToAction("Welcome", "StudentHome");
            }
            return View(studentResponses);
        }
    }
}