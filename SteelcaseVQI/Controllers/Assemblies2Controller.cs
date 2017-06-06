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
    public class Assemblies2Controller : Controller
    {
        private SteelcaseVQIEntities3 db = new SteelcaseVQIEntities3();

        // GET: Assemblies2
        public async Task<ActionResult> Index()
        {
            return View(await db.Assemblies.ToListAsync());
        }

        // GET: Assemblies2/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Assembly assembly = await db.Assemblies.FindAsync(id);
            if (assembly == null)
            {
                return HttpNotFound();
            }
            return View(assembly);
        }

        // GET: Assemblies2/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Assemblies2/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,Nbr,Description,Image,ComponentID")] Assembly assembly)
        {
            if (ModelState.IsValid)
            {
                db.Assemblies.Add(assembly);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(assembly);
        }

        // GET: Assemblies2/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Assembly assembly = await db.Assemblies.FindAsync(id);
            if (assembly == null)
            {
                return HttpNotFound();
            }
            return View(assembly);
        }

        // POST: Assemblies2/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,Nbr,Description,Image,ComponentID")] Assembly assembly)
        {
            if (ModelState.IsValid)
            {
                db.Entry(assembly).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(assembly);
        }

        // GET: Assemblies2/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Assembly assembly = await db.Assemblies.FindAsync(id);
            if (assembly == null)
            {
                return HttpNotFound();
            }
            return View(assembly);
        }

        // POST: Assemblies2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Assembly assembly = await db.Assemblies.FindAsync(id);
            db.Assemblies.Remove(assembly);
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
