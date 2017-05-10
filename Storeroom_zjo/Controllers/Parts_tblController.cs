using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Storeroom_zjo.Models;

namespace Storeroom_zjo.Controllers
{
    public class Parts_tblController : Controller
    {
        private StoreroomEntities db = new StoreroomEntities();

        // GET: Parts_tbl
        public ActionResult Index()
        {
            var parts_tbl = db.Parts_tbl.Include(p => p.PartsManufacturers_tbl);
            return View(parts_tbl.ToList());
        }

        // GET: Parts_tbl/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Parts_tbl parts_tbl = db.Parts_tbl.Find(id);
            if (parts_tbl == null)
            {
                return HttpNotFound();
            }
            return View(parts_tbl);
        }

        // GET: Parts_tbl/Create
        public ActionResult Create()
        {
            ViewBag.IdManufacturer = new SelectList(db.PartsManufacturers_tbl, "IdManufacturer", "Company");
            return View();
        }

        // POST: Parts_tbl/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdPart,IdManufacturer,PartName,ManufacturerCode,Orginal,Artificial,Quantity,MinimalStock,AutomaticOrder")] Parts_tbl parts_tbl)
        {
            if (ModelState.IsValid)
            {
                db.Parts_tbl.Add(parts_tbl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdManufacturer = new SelectList(db.PartsManufacturers_tbl, "IdManufacturer", "Company", parts_tbl.IdManufacturer);
            return View(parts_tbl);
        }

        // GET: Parts_tbl/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Parts_tbl parts_tbl = db.Parts_tbl.Find(id);
            if (parts_tbl == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdManufacturer = new SelectList(db.PartsManufacturers_tbl, "IdManufacturer", "Company", parts_tbl.IdManufacturer);
            return View(parts_tbl);
        }

        // POST: Parts_tbl/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdPart,IdManufacturer,PartName,ManufacturerCode,Orginal,Artificial,Quantity,MinimalStock,AutomaticOrder")] Parts_tbl parts_tbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(parts_tbl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdManufacturer = new SelectList(db.PartsManufacturers_tbl, "IdManufacturer", "Company", parts_tbl.IdManufacturer);
            return View(parts_tbl);
        }

        // GET: Parts_tbl/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Parts_tbl parts_tbl = db.Parts_tbl.Find(id);
            if (parts_tbl == null)
            {
                return HttpNotFound();
            }
            return View(parts_tbl);
        }

        // POST: Parts_tbl/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Parts_tbl parts_tbl = db.Parts_tbl.Find(id);
            db.Parts_tbl.Remove(parts_tbl);
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
