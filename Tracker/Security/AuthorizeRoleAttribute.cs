using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tracker.Models.DB;
using Tracker.Models.EntityManager;

namespace Tracker.Security
{
    public class AuthorizeRoleAttribute : AuthorizeAttribute
    {
        private readonly string[] userAssignedRoles;
        public AuthorizeRoleAttribute(params string[] roles)
        {
            this.userAssignedRoles = roles;
        }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            bool authorize = false;
            using (StudentTrackerEntities db = new StudentTrackerEntities())
            {
                StudentManager UM = new StudentManager();
                foreach (var roles in userAssignedRoles)
                {
                    authorize = UM.IsUserInRole(httpContext.User.Identity.Name, roles);
                    if (authorize)
                        return authorize;
                }
            }
            return authorize;
        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectResult("~/StudentHome/Unauthorised");
        }
    }
}
