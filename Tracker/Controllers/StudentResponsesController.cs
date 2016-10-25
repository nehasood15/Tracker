using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Tracker.Models.DB;
using Tracker.Models.ViewModels;

namespace Tracker.Controllers
{
    public class StudentResponsesController : Controller
    {
        // private RegistrationViewModel db = new RegistrationViewModel();

        // GET: StudentResponses
        StudentTrackerEntities db = new StudentTrackerEntities();

        public ActionResult Index()
        {
            var responses = db.StudentResponses.Include(s => s.Question).Include(s => s.Student);
            return View(responses.ToList());
        }

        // GET: StudentResponses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentResponse studentResponse = db.StudentResponses.Find(id);
            if (studentResponse == null)
            {
                return HttpNotFound();
            }
            return View(studentResponse);
        }

        // GET: StudentResponses/Create
        public ActionResult Create()
        {
            //List<Question> questions= db.Questions.ToList();
            ViewBag.questionId = new SelectList(db.Questions, "questionId", "questionDecription");
            ViewBag.studentId = new SelectList(db.Students, "studentId", "firstName");
            return View();
        }

        // POST: StudentResponses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "questionId,studentId,response")] StudentResponse studentResponse)
        {
            if (ModelState.IsValid)
            {
                db.StudentResponses.Add(studentResponse);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.questionId = new SelectList(db.Questions, "questionId", "questionDecription", studentResponse.questionId);
            ViewBag.studentId = new SelectList(db.Students, "studentId", "firstName", studentResponse.studentId);
            return View(studentResponse);
        }

        // GET: StudentResponses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentResponse studentResponse = db.StudentResponses.Find(id);
            if (studentResponse == null)
            {
                return HttpNotFound();
            }
            ViewBag.questionId = new SelectList(db.Questions, "questionId", "questionDecription", studentResponse.questionId);
            ViewBag.studentId = new SelectList(db.Students, "studentId", "firstName", studentResponse.studentId);
            return View(studentResponse);
        }

        // POST: StudentResponses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "questionId,studentId,response")] StudentResponse studentResponse)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentResponse).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.questionId = new SelectList(db.Questions, "questionId", "questionDecription", studentResponse.questionId);
            ViewBag.studentId = new SelectList(db.Students, "studentId", "firstName", studentResponse.studentId);
            return View(studentResponse);
        }

        // GET: StudentResponses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentResponse studentResponse = db.StudentResponses.Find(id);
            if (studentResponse == null)
            {
                return HttpNotFound();
            }
            return View(studentResponse);
        }

        // POST: StudentResponses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StudentResponse studentResponse = db.StudentResponses.Find(id);
            db.StudentResponses.Remove(studentResponse);
            db.SaveChanges();
            return RedirectToAction("Index");
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
