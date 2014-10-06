using NesclPms.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NesclPms.WebUI.Controllers
{
    public class VehicleBillController : Controller
    {
        private IEntitiesRepository repository;

        public VehicleBillController(IEntitiesRepository rep)
        {
            repository = rep;
        }

        // GET: VehicleBill
        public ViewResult List()
        {
            return View(repository.VehicleBills);
        }

        //public ViewResult Create()
        //{

        //}
    }
}