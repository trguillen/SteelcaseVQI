using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SteelcaseVQI.Models;

namespace SteelcaseVQI.Controllers
{
    public class AssemblyComponentsController : Controller
    {
        private SteelcaseVQIEntities2 db = new SteelcaseVQIEntities2();

        // GET: AssemblyComponents
        public async Task<ActionResult> Index()
        {
            return View(await db.AssemblyComponents.ToListAsync());
        }

        // GET: AssemblyComponents/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssemblyComponent assemblyComponent = await db.AssemblyComponents.FindAsync(id);
            if (assemblyComponent == null)
            {
                return HttpNotFound();
            }
            return View(assemblyComponent);
        }

        // GET: AssemblyComponents/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AssemblyComponents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,AssemblyID,ComponentID")] AssemblyComponent assemblyComponent)
        {
            if (ModelState.IsValid)
            {
                db.AssemblyComponents.Add(assemblyComponent);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(assemblyComponent);
        }

        // GET: AssemblyComponents/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssemblyComponent assemblyComponent = await db.AssemblyComponents.FindAsync(id);
            if (assemblyComponent == null)
            {
                return HttpNotFound();
            }
            return View(assemblyComponent);
        }

        // POST: AssemblyComponents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,AssemblyID,ComponentID")] AssemblyComponent assemblyComponent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(assemblyComponent).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(assemblyComponent);
        }

        // GET: AssemblyComponents/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssemblyComponent assemblyComponent = await db.AssemblyComponents.FindAsync(id);
            if (assemblyComponent == null)
            {
                return HttpNotFound();
            }
            return View(assemblyComponent);
        }

        // POST: AssemblyComponents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            AssemblyComponent assemblyComponent = await db.AssemblyComponents.FindAsync(id);
            db.AssemblyComponents.Remove(assemblyComponent);
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
