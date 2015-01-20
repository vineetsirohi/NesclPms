using System.Data.Entity;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using NesclPms.Domain.Concrete;
using NesclPms.Domain.Entities;

namespace NesclPms.WebUI.Controllers
{
    public class LoaPriceComponentsController : Controller
    {
        private EfDbContext db = new EfDbContext();

        // GET: LoaPriceComponents
        public async Task<ActionResult> Index()
        {
            return View(await db.LoaPriceComponents.ToListAsync());
        }

        // GET: LoaPriceComponents/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaPriceComponent loaPriceComponent = await db.LoaPriceComponents.FindAsync(id);
            if (loaPriceComponent == null)
            {
                return HttpNotFound();
            }
            return View(loaPriceComponent);
        }

        // GET: LoaPriceComponents/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LoaPriceComponents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,LoaPackageId,Name,Price")] LoaPriceComponent loaPriceComponent)
        {
            if (ModelState.IsValid)
            {
                db.LoaPriceComponents.Add(loaPriceComponent);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(loaPriceComponent);
        }

        // GET: LoaPriceComponents/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaPriceComponent loaPriceComponent = await db.LoaPriceComponents.FindAsync(id);
            if (loaPriceComponent == null)
            {
                return HttpNotFound();
            }
            return View(loaPriceComponent);
        }

        // POST: LoaPriceComponents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,LoaPackageId,Name,Price")] LoaPriceComponent loaPriceComponent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loaPriceComponent).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(loaPriceComponent);
        }

        // GET: LoaPriceComponents/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaPriceComponent loaPriceComponent = await db.LoaPriceComponents.FindAsync(id);
            if (loaPriceComponent == null)
            {
                return HttpNotFound();
            }
            return View(loaPriceComponent);
        }

        // POST: LoaPriceComponents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            LoaPriceComponent loaPriceComponent = await db.LoaPriceComponents.FindAsync(id);
            db.LoaPriceComponents.Remove(loaPriceComponent);
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
