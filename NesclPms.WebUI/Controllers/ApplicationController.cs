using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using NesclPms.WebUI.Infrastructure;
using NesclPms.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Threading.Tasks;

namespace NesclPms.WebUI.Controllers
{
    public class ApplicationController : Controller
    {
        public ApplicationController()
        {

        }

        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            base.Initialize(requestContext);
            ViewData["userdetails"] = LabelName();
        }

        public String LabelName()
        {
            if (CurrentUser != null)
            {
                return CurrentUser.LabelName;
            }
            else
            {
                return HttpContext.User.Identity.Name;
            }
        }

        private AppUser CurrentUser
        {
            get
            {
                return UserManager.FindByName(HttpContext.User.Identity.Name);
            }
        }

        private AppUserManager UserManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<AppUserManager>();
            }
        }
    }
}