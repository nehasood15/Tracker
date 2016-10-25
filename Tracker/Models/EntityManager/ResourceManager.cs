using Tracker.Models.DB;
using Tracker.Models.ViewModels;
using System.Data.Entity;
using System.Linq;
using System.Collections.Generic;

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
        public List<ResourceViewModel> GetAllResources()
        {
            using (StudentTrackerEntities db = new StudentTrackerEntities())
            {
                List<Resource> resources = db.Resources.ToList();
                List<ResourceViewModel> resourcesview = new List<ResourceViewModel>();
                foreach (Resource r in resources)
                {
                    ResourceViewModel res = new ResourceViewModel();
                    res.resourceId = r.resourceId;
                    res.resourceName = r.resourceName;
                    res.resourceLink = r.resourceLink;
                    res.proficiencyId = r.proficiencyId;
                    res.description = r.description;
                    resourcesview.Add(res);
                }
                return resourcesview;

            }
        }

        public List<ResourceViewModel> GetResourcesBasedOnProficiencyLevel(int proficiencyId)
        {
            using (StudentTrackerEntities db = new StudentTrackerEntities())
            {
                var resources = db.Resources.Where(x => x.proficiencyId.Equals(proficiencyId)).ToList();

                List<ResourceViewModel> resourcesview = new List<ResourceViewModel>();
                foreach (Resource r in resources)
                {
                    ResourceViewModel res = new ResourceViewModel();
                    res.resourceId = r.resourceId;
                    res.resourceName = r.resourceName;
                    res.resourceLink = r.resourceLink;
                    res.proficiencyId = r.proficiencyId;
                    res.description = r.description;
                    resourcesview.Add(res);
                }
                return resourcesview;
            }
        }
    }
}