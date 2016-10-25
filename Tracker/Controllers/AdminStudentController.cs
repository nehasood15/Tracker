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
    public class AdminStudentController : Controller
    {
        private StudentTrackerEntities db = new StudentTrackerEntities();

        // GET: AdminStudent
        public ActionResult Index()
        {
            return View(db.Students.ToList());
        }

        // GET: AdminStudent/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student studentViewModel = db.Students.Find(id);
            if (studentViewModel == null)
            {
                return HttpNotFound();
            }
            return View(studentViewModel);
        }

        // GET: AdminStudent/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminStudent/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "studentId,firstName,lastName,universityName,email,password,proficiencyId")] Student studentViewModel)
        {
            if (ModelState.IsValid)
            {
                db.Students.Add(studentViewModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(studentViewModel);
        }

        // GET: AdminStudent/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student studentViewModel = db.Students.Find(id);
            if (studentViewModel == null)
            {
                return HttpNotFound();
            }
            return View(studentViewModel);
        }

        // POST: AdminStudent/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "studentId,firstName,lastName,universityName,email,password,proficiencyId")] StudentViewModel studentViewModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentViewModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(studentViewModel);
        }

        // GET: AdminStudent/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student studentViewModel = db.Students.Find(id);
            if (studentViewModel == null)
            {
                return HttpNotFound();
            }
            return View(studentViewModel);
        }

        // POST: AdminStudent/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Student studentViewModel = db.Students.Find(id);
            db.Students.Remove(studentViewModel);
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
