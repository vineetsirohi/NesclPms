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
            if (User != null)
            {
                ViewData["userdetails"] = LabelName(User.Identity.GetUserId());
            }
        }

        public String LabelName(string id)
        {
            AppUser user = UserManager.FindById(id);
            if (user != null)
            {
                return user.LabelName;
            }
            else
            {
                return "User";
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