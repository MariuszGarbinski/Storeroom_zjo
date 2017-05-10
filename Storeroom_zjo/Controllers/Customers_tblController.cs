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
    public class Customers_tblController : Controller
    {
        private StoreroomEntities db = new StoreroomEntities();

        // GET: Customers_tbl
        public ActionResult Index()
        {
            var customers_tbl = db.Customers_tbl.Include(c => c.Vehicles_tbl);
            return View(customers_tbl.ToList());
        }

        // GET: Customers_tbl/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customers_tbl customers_tbl = db.Customers_tbl.Find(id);
            if (customers_tbl == null)
            {
                return HttpNotFound();
            }
            return View(customers_tbl);
        }

        // GET: Customers_tbl/Create
        public ActionResult Create()
        {
            ViewBag.IdVehicle = new SelectList(db.Vehicles_tbl, "IdVehicle", "VehicleBrand");
            return View();
        }

        // POST: Customers_tbl/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdCustomer,IdVehicle,Name,Surname,Address,PostCode,City,Country,Email,PhoneNumber")] Customers_tbl customers_tbl)
        {
            if (ModelState.IsValid)
            {
                db.Customers_tbl.Add(customers_tbl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdVehicle = new SelectList(db.Vehicles_tbl, "IdVehicle", "VehicleBrand", customers_tbl.IdVehicle);
            return View(customers_tbl);
        }

        // GET: Customers_tbl/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customers_tbl customers_tbl = db.Customers_tbl.Find(id);
            if (customers_tbl == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdVehicle = new SelectList(db.Vehicles_tbl, "IdVehicle", "VehicleBrand", customers_tbl.IdVehicle);
            return View(customers_tbl);
        }

        // POST: Customers_tbl/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdCustomer,IdVehicle,Name,Surname,Address,PostCode,City,Country,Email,PhoneNumber")] Customers_tbl customers_tbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customers_tbl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdVehicle = new SelectList(db.Vehicles_tbl, "IdVehicle", "VehicleBrand", customers_tbl.IdVehicle);
            return View(customers_tbl);
        }

        // GET: Customers_tbl/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customers_tbl customers_tbl = db.Customers_tbl.Find(id);
            if (customers_tbl == null)
            {
                return HttpNotFound();
            }
            return View(customers_tbl);
        }

        // POST: Customers_tbl/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customers_tbl customers_tbl = db.Customers_tbl.Find(id);
            db.Customers_tbl.Remove(customers_tbl);
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
