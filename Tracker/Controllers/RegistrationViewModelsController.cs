//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.Entity;
//using System.Linq;
//using System.Net;
//using System.Web;
//using System.Web.Mvc;
//using Tracker.Models.DB;
//using Tracker.Models.ViewModels;

//namespace Tracker.Controllers
//{
//    public class RegistrationViewModelsController : Controller
//    {
//        private StudentTrackerEntities db = new StudentTrackerEntities();

//        // GET: RegistrationViewModels
//        public ActionResult Index()
//        {
//            return View(db.RegistrationViewModels.ToList());
//        }

//        // GET: RegistrationViewModels/Details/5
//        public ActionResult Details(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            RegistrationViewModel registrationViewModel = db.RegistrationViewModels.Find(id);
//            if (registrationViewModel == null)
//            {
//                return HttpNotFound();
//            }
//            return View(registrationViewModel);
//        }

//        // GET: RegistrationViewModels/Create
//        public ActionResult Create()
//        {
//            return View();
//        }

//        // POST: RegistrationViewModels/Create
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Create([Bind(Include = "id")] RegistrationViewModel registrationViewModel)
//        {
//            if (ModelState.IsValid)
//            {
//                db.RegistrationViewModels.Add(registrationViewModel);
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }

//            return View(registrationViewModel);
//        }

//        // GET: RegistrationViewModels/Edit/5
//        public ActionResult Edit(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            RegistrationViewModel registrationViewModel = db.RegistrationViewModels.Find(id);
//            if (registrationViewModel == null)
//            {
//                return HttpNotFound();
//            }
//            return View(registrationViewModel);
//        }

//        // POST: RegistrationViewModels/Edit/5
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Edit([Bind(Include = "id")] RegistrationViewModel registrationViewModel)
//        {
//            if (ModelState.IsValid)
//            {
//                db.Entry(registrationViewModel).State = EntityState.Modified;
//                db.SaveChanges();
//                return RedirectToAction("Index");
//            }
//            return View(registrationViewModel);
//        }

//        // GET: RegistrationViewModels/Delete/5
//        public ActionResult Delete(int? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            RegistrationViewModel registrationViewModel = db.RegistrationViewModels.Find(id);
//            if (registrationViewModel == null)
//            {
//                return HttpNotFound();
//            }
//            return View(registrationViewModel);
//        }

//        // POST: RegistrationViewModels/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public ActionResult DeleteConfirmed(int id)
//        {
//            RegistrationViewModel registrationViewModel = db.RegistrationViewModels.Find(id);
//            db.RegistrationViewModels.Remove(registrationViewModel);
//            db.SaveChanges();
//            return RedirectToAction("Index");
//        }

//        protected override void Dispose(bool disposing)
//        {
//            if (disposing)
//            {
//                db.Dispose();
//            }
//            base.Dispose(disposing);
//        }
//    }
//}
