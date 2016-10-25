using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Tracker.Models.DB;

namespace Tracker.Controllers
{
    public class StudentsAdminController : Controller
    {
        private StudentTrackerEntities db = new StudentTrackerEntities();

        // GET: StudentsAdmin
        public ActionResult Index()
        {
            var students = db.Students.Include(s => s.ProficiencyLevel);
            return View(students.ToList());
        }

        // GET: StudentsAdmin/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: StudentsAdmin/Create
        public ActionResult Create()
        {
            ViewBag.proficiencyId = new SelectList(db.ProficiencyLevels, "proficiencyId", "proficiencyLevel");
            return View();
        }

        // POST: StudentsAdmin/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "studentId,firstName,lastName,universityName,email,proficiencyId,password,role")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Students.Add(student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.proficiencyId = new SelectList(db.ProficiencyLevels, "proficiencyId", "proficiencyLevel", student.proficiencyId);
            return View(student);
        }

        // GET: StudentsAdmin/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            ViewBag.proficiencyId = new SelectList(db.ProficiencyLevels, "proficiencyId", "proficiencyLevel", student.proficiencyId);
            return View(student);
        }

        // POST: StudentsAdmin/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "studentId,firstName,lastName,universityName,email,proficiencyId,password,role")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.proficiencyId = new SelectList(db.ProficiencyLevels, "proficiencyId", "proficiencyLevel", student.proficiencyId);
            return View(student);
        }

        // GET: StudentsAdmin/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: StudentsAdmin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Student student = db.Students.Find(id);
            db.Students.Remove(student);
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
