using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SteelcaseVQI.Models;

namespace SteelcaseVQI.Controllers
{
    public class AssembliesController : Controller
    {
        private SteelcaseVQIEntities db = new SteelcaseVQIEntities();

        // GET: Assemblies
        public ActionResult Index()
        {
            return View(db.Assemblies.ToList());
        }

        // GET: Assemblies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Assembly assembly = db.Assemblies.Find(id);
            if (assembly == null)
            {
                return HttpNotFound();
            }
            return View(assembly);
        }

        // GET: Assemblies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Assemblies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nbr,Description,Image")] Assembly assembly)
        {
            if (ModelState.IsValid)
            {
                db.Assemblies.Add(assembly);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(assembly);
        }

        // GET: Assemblies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Assembly assembly = db.Assemblies.Find(id);
            if (assembly == null)
            {
                return HttpNotFound();
            }
            return View(assembly);
        }

        // POST: Assemblies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nbr,Description,Image")] Assembly assembly)
        {
            if (ModelState.IsValid)
            {
                db.Entry(assembly).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(assembly);
        }

        // GET: Assemblies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Assembly assembly = db.Assemblies.Find(id);
            if (assembly == null)
            {
                return HttpNotFound();
            }
            return View(assembly);
        }

        // POST: Assemblies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Assembly assembly = db.Assemblies.Find(id);
            db.Assemblies.Remove(assembly);
            db.SaveChanges();
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
