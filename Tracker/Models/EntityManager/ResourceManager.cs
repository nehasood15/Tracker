using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tracker.Models.DB;
using Tracker.Models.ViewModels;

namespace Tracker.Models.EntityManager
{
    public class ResourceManager
    {
        public void AddNewResource(ResourceViewModel userModel)
        {
            using (StudentTrackerEntities db = new StudentTrackerEntities())
            {

                Resource resource = new Resource();
                resource.resourceName = userModel.resourceName;
                resource.resourceLink = userModel.resourceLink;
                resource.description = userModel.description;
                resource.proficiencyId = userModel.proficiencyId;
                db.Resources.Add(resource);
                db.SaveChanges();
            }
        }

        public List<ResourceViewModel> GetResources()
        {
            using (StudentTrackerEntities db = new StudentTrackerEntities())
            {
                List<ResourceViewModel> resources = db.Resources.Select(z => new ResourceViewModel {
                    resourceId = z.resourceId,
                    resourceName = z.resourceName,
                    description = z.description,
                    resourceLink =  z.resourceLink     }).ToList();

                return resources;


            }
        }

        public List<ResourceViewModel> GetResources(int proficiencyId)
        {
            using (StudentTrackerEntities db = new StudentTrackerEntities())
            {
                var resources = db.Resources.Where(x => x.proficiencyId.Equals(proficiencyId)).ToList();

                List<ResourceViewModel> resourcesview = new List<ResourceViewModel>();
                foreach( Resource r in resources)
                {
                    ResourceViewModel res = new ResourceViewModel();
                    res.resourceId = r.resourceId;
                    res.resourceName = r.resourceName;
                    res.resourceLink = r.resourceLink;
                    res.proficiencyId = r.proficiencyId;
                    res.description = r.description;

                }

                return resourcesview;


            }
        }
    }
}