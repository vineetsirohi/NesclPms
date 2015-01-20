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

namespace NesclPms.WebUI.Controllers
{
    public class LoaPackagesController : Controller
    {
        private EfDbContext db = new EfDbContext();

        // GET: LoaPackages
        public async Task<ActionResult> Index()
        {
            var loaPackages = db.LoaPackages.Include(l => l.Agency);
            return View(await loaPackages.ToListAsync());
        }

        // GET: LoaPackages/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaPackage loaPackage = await db.LoaPackages.FindAsync(id);
            if (loaPackage == null)
            {
                return HttpNotFound();
            }
            return View(loaPackage);
        }

        // GET: LoaPackages/Create
        public ActionResult Create()
        {
            ViewBag.AgencyId = new SelectList(db.Agencies, "ID", "Name");
            return View();
        }

        // POST: LoaPackages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,No,Description,Date,AgencyId")] LoaPackage loaPackage)
        {
            if (ModelState.IsValid)
            {
                db.LoaPackages.Add(loaPackage);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.AgencyId = new SelectList(db.Agencies, "ID", "Name", loaPackage.AgencyId);
            return View(loaPackage);
        }

        // GET: LoaPackages/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaPackage loaPackage = await db.LoaPackages.FindAsync(id);
            if (loaPackage == null)
            {
                return HttpNotFound();
            }
            ViewBag.AgencyId = new SelectList(db.Agencies, "ID", "Name", loaPackage.AgencyId);
            return View(loaPackage);
        }

        // POST: LoaPackages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,No,Description,Date,AgencyId")] LoaPackage loaPackage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loaPackage).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.AgencyId = new SelectList(db.Agencies, "ID", "Name", loaPackage.AgencyId);
            return View(loaPackage);
        }

        // GET: LoaPackages/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaPackage loaPackage = await db.LoaPackages.FindAsync(id);
            if (loaPackage == null)
            {
                return HttpNotFound();
            }
            return View(loaPackage);
        }

        // POST: LoaPackages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            LoaPackage loaPackage = await db.LoaPackages.FindAsync(id);
            db.LoaPackages.Remove(loaPackage);
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
