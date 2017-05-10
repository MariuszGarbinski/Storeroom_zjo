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
    public class PartsManufacturers_tblController : Controller
    {
        private StoreroomEntities db = new StoreroomEntities();

        // GET: PartsManufacturers_tbl
        public ActionResult Index()
        {
            return View(db.PartsManufacturers_tbl.ToList());
        }

        // GET: PartsManufacturers_tbl/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PartsManufacturers_tbl partsManufacturers_tbl = db.PartsManufacturers_tbl.Find(id);
            if (partsManufacturers_tbl == null)
            {
                return HttpNotFound();
            }
            return View(partsManufacturers_tbl);
        }

        // GET: PartsManufacturers_tbl/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PartsManufacturers_tbl/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdManufacturer,Company,Address,PostCode,City,Country,PhoneNumber,Mail")] PartsManufacturers_tbl partsManufacturers_tbl)
        {
            if (ModelState.IsValid)
            {
                db.PartsManufacturers_tbl.Add(partsManufacturers_tbl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(partsManufacturers_tbl);
        }

        // GET: PartsManufacturers_tbl/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PartsManufacturers_tbl partsManufacturers_tbl = db.PartsManufacturers_tbl.Find(id);
            if (partsManufacturers_tbl == null)
            {
                return HttpNotFound();
            }
            return View(partsManufacturers_tbl);
        }

        // POST: PartsManufacturers_tbl/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdManufacturer,Company,Address,PostCode,City,Country,PhoneNumber,Mail")] PartsManufacturers_tbl partsManufacturers_tbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(partsManufacturers_tbl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(partsManufacturers_tbl);
        }

        // GET: PartsManufacturers_tbl/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PartsManufacturers_tbl partsManufacturers_tbl = db.PartsManufacturers_tbl.Find(id);
            if (partsManufacturers_tbl == null)
            {
                return HttpNotFound();
            }
            return View(partsManufacturers_tbl);
        }

        // POST: PartsManufacturers_tbl/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PartsManufacturers_tbl partsManufacturers_tbl = db.PartsManufacturers_tbl.Find(id);
            db.PartsManufacturers_tbl.Remove(partsManufacturers_tbl);
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
