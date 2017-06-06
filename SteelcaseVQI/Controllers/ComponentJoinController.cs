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
    public class ComponentJoinController : Controller
    {
        private SteelcaseVQIEntities2 db = new SteelcaseVQIEntities2();

        // GET: ComponentJoin
        public async Task<ActionResult> Index()
        {
            return View(await db.Assemblies.ToListAsync());
        }

        // GET: ComponentJoin/Details/5
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

        // GET: ComponentJoin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ComponentJoin/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,Nbr,Description,Image")] Assembly assembly)
        {
            if (ModelState.IsValid)
            {
                db.Assemblies.Add(assembly);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(assembly);
        }

        // GET: ComponentJoin/Edit/5
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

        // POST: ComponentJoin/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,Nbr,Description,Image")] Assembly assembly)
        {
            if (ModelState.IsValid)
            {
                db.Entry(assembly).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(assembly);
        }

        // GET: ComponentJoin/Delete/5
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

        // POST: ComponentJoin/Delete/5
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
