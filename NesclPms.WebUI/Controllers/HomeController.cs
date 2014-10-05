using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NesclPms.WebUI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "NESCL (NTPC Electric Supply Comapany Ltd.) is a wholly owned subsidiary of NTPC, the power giant powering India's growth";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Address:";

            return View();
        }
    }
}