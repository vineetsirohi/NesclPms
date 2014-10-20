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
    public class DemoModelsController : ApplicationController
    {
        private EFDbContext db = new EFDbContext();

        // GET: DemoModels
        public async Task<ActionResult> Index()
        {
            return View(await db.DemoModels.ToListAsync());
        }

        // GET: DemoModels/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DemoModel demoModel = await db.DemoModels.FindAsync(id);
            if (demoModel == null)
            {
                return HttpNotFound();
            }
            return View(demoModel);
        }

        // GET: DemoModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DemoModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,Title,ReleaseDate,Price")] DemoModel demoModel)
        {
            if (ModelState.IsValid)
            {
                db.DemoModels.Add(demoModel);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(demoModel);
        }

        // GET: DemoModels/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DemoModel demoModel = await db.DemoModels.FindAsync(id);
            if (demoModel == null)
            {
                return HttpNotFound();
            }
            return View(demoModel);
        }

        // POST: DemoModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,Title,ReleaseDate,Price")] DemoModel demoModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(demoModel).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(demoModel);
        }

        // GET: DemoModels/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DemoModel demoModel = await db.DemoModels.FindAsync(id);
            if (demoModel == null)
            {
                return HttpNotFound();
            }
            return View(demoModel);
        }

        // POST: DemoModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            DemoModel demoModel = await db.DemoModels.FindAsync(id);
            db.DemoModels.Remove(demoModel);
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
