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
    public class LoaAmendmentsController : Controller
    {
        private EfDbContext db = new EfDbContext();

        // GET: LoaAmendments
        public async Task<ActionResult> Index()
        {
            var loaAmendments = db.LoaAmendments.Include(l => l.LoaPackage);
            return View(await loaAmendments.ToListAsync());
        }

        // GET: LoaAmendments/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaAmendment loaAmendment = await db.LoaAmendments.FindAsync(id);
            if (loaAmendment == null)
            {
                return HttpNotFound();
            }
            return View(loaAmendment);
        }

        // GET: LoaAmendments/Create
        public ActionResult Create()
        {
            ViewBag.LoaPackageId = new SelectList(db.LoaPackages, "ID", "No");
            return View();
        }

        // POST: LoaAmendments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,LoaPackageId,Name,Date")] LoaAmendment loaAmendment)
        {
            if (ModelState.IsValid)
            {
                db.LoaAmendments.Add(loaAmendment);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.LoaPackageId = new SelectList(db.LoaPackages, "ID", "No", loaAmendment.LoaPackageId);
            return View(loaAmendment);
        }

        // GET: LoaAmendments/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaAmendment loaAmendment = await db.LoaAmendments.FindAsync(id);
            if (loaAmendment == null)
            {
                return HttpNotFound();
            }
            ViewBag.LoaPackageId = new SelectList(db.LoaPackages, "ID", "No", loaAmendment.LoaPackageId);
            return View(loaAmendment);
        }

        // POST: LoaAmendments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,LoaPackageId,Name,Date")] LoaAmendment loaAmendment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loaAmendment).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.LoaPackageId = new SelectList(db.LoaPackages, "ID", "No", loaAmendment.LoaPackageId);
            return View(loaAmendment);
        }

        // GET: LoaAmendments/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaAmendment loaAmendment = await db.LoaAmendments.FindAsync(id);
            if (loaAmendment == null)
            {
                return HttpNotFound();
            }
            return View(loaAmendment);
        }

        // POST: LoaAmendments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            LoaAmendment loaAmendment = await db.LoaAmendments.FindAsync(id);
            db.LoaAmendments.Remove(loaAmendment);
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
