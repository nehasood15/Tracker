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
    public class ResourcesController : Controller
    {
        // GET: Resources
        [HttpGet]
        public ActionResult Index()
        {
            ResourceManager ResourceManager = new ResourceManager();
                      
            return View();
        }

        [HttpGet]
        public ActionResult AddNewResource()
        {
            ResourceManager ResourceManager = new ResourceManager();

            return View();
        }

        [HttpPost]
            
        public ActionResult AddNewResource(ResourceViewModel resourceModel)
        {
            if (ModelState.IsValid)
            {
                ResourceManager ResourceManager = new ResourceManager();

                ResourceManager.AddNewResource(resourceModel);
                //return RedirectToAction("Index", "Resources");
                return RedirectToAction("AddNewResource", "Resources");



            }
            else
                    ModelState.AddModelError("", "Error Adding Resource. Please fill all mandatory fields and Try Again");
            return View();
        }


    }
}