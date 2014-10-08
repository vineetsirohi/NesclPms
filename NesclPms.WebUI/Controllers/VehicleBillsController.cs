using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NesclPms.Domain.Concrete;
using NesclPms.Domain.Entities;
using NesclPms.Domain.Abstract;

namespace NesclPms.WebUI.Controllers
{
    [Authorize]
    public class VehicleBillsController : Controller
    {
        private IEntitiesRepository repository;

        private EFDbContext db; // = new EFDbContext();

        public VehicleBillsController(IEntitiesRepository repo)
        {
            repository = repo;
            db = repository.Context;
        }
               

        // GET: VehicleBills
        public async Task<ActionResult> Index()
        {
            return View(await db.VehicleBills.ToListAsync());
        }

        // GET: VehicleBills/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleBill vehicleBill = await db.VehicleBills.FindAsync(id);
            if (vehicleBill == null)
            {
                return HttpNotFound();
            }
            return View(vehicleBill);
        }

        // GET: VehicleBills/Create
        [Authorize(Roles="site_engg")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: VehicleBills/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,Name,Date,Amount,Comments,IsPrepared,IsVerified,IsPassed")] VehicleBill vehicleBill)
        {
            if (ModelState.IsValid)
            {
                db.VehicleBills.Add(vehicleBill);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(vehicleBill);
        }

        // GET: VehicleBills/Edit/5
        [Authorize(Roles = "site_engg,srm,finance")]
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleBill vehicleBill = await db.VehicleBills.FindAsync(id);
            if (vehicleBill == null)
            {
                return HttpNotFound();
            }
            return View(vehicleBill);
        }

        // POST: VehicleBills/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,Name,Date,Amount,Comments,IsPrepared,IsVerified,IsPassed")] VehicleBill vehicleBill)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vehicleBill).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(vehicleBill);
        }

        // GET: VehicleBills/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleBill vehicleBill = await db.VehicleBills.FindAsync(id);
            if (vehicleBill == null)
            {
                return HttpNotFound();
            }
            return View(vehicleBill);
        }

        // POST: VehicleBills/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            VehicleBill vehicleBill = await db.VehicleBills.FindAsync(id);
            db.VehicleBills.Remove(vehicleBill);
            await db.SaveChangesAsync();
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
