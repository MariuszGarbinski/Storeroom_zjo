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
    public class Vehicles_tblController : Controller
    {
        private StoreroomEntities db = new StoreroomEntities();

        // GET: Vehicles_tbl
        public ActionResult Index()
        {
            return View(db.Vehicles_tbl.ToList());
        }

        // GET: Vehicles_tbl/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicles_tbl vehicles_tbl = db.Vehicles_tbl.Find(id);
            if (vehicles_tbl == null)
            {
                return HttpNotFound();
            }
            return View(vehicles_tbl);
        }

        // GET: Vehicles_tbl/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Vehicles_tbl/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdVehicle,VehicleBrand,Model,VehicleType,VINnumber,REGnumber")] Vehicles_tbl vehicles_tbl)
        {
            if (ModelState.IsValid)
            {
                db.Vehicles_tbl.Add(vehicles_tbl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vehicles_tbl);
        }

        // GET: Vehicles_tbl/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicles_tbl vehicles_tbl = db.Vehicles_tbl.Find(id);
            if (vehicles_tbl == null)
            {
                return HttpNotFound();
            }
            return View(vehicles_tbl);
        }

        // POST: Vehicles_tbl/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdVehicle,VehicleBrand,Model,VehicleType,VINnumber,REGnumber")] Vehicles_tbl vehicles_tbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vehicles_tbl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vehicles_tbl);
        }

        // GET: Vehicles_tbl/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicles_tbl vehicles_tbl = db.Vehicles_tbl.Find(id);
            if (vehicles_tbl == null)
            {
                return HttpNotFound();
            }
            return View(vehicles_tbl);
        }

        // POST: Vehicles_tbl/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vehicles_tbl vehicles_tbl = db.Vehicles_tbl.Find(id);
            db.Vehicles_tbl.Remove(vehicles_tbl);
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
