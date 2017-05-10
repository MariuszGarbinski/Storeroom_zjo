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
    public class Repairs_tblController : Controller
    {
        private StoreroomEntities db = new StoreroomEntities();

        // GET: Repairs_tbl
        public ActionResult Index()
        {
            var repairs_tbl = db.Repairs_tbl.Include(r => r.Customers_tbl).Include(r => r.Parts_tbl);
            return View(repairs_tbl.ToList());
        }

        // GET: Repairs_tbl/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Repairs_tbl repairs_tbl = db.Repairs_tbl.Find(id);
            if (repairs_tbl == null)
            {
                return HttpNotFound();
            }
            return View(repairs_tbl);
        }

        // GET: Repairs_tbl/Create
        public ActionResult Create()
        {
            ViewBag.IdCustomer = new SelectList(db.Customers_tbl, "IdCustomer", "Name");
            ViewBag.IdPart = new SelectList(db.Parts_tbl, "IdPart", "PartName");
            return View();
        }

        // POST: Repairs_tbl/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdRepair,IdCustomer,DateOfCarReception,RepairStartDate,Station,RepairEndDate,IdPart,QuantityOfParts,Description,Cost,Discount")] Repairs_tbl repairs_tbl)
        {
            if (ModelState.IsValid)
            {
                db.Repairs_tbl.Add(repairs_tbl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdCustomer = new SelectList(db.Customers_tbl, "IdCustomer", "Name", repairs_tbl.IdCustomer);
            ViewBag.IdPart = new SelectList(db.Parts_tbl, "IdPart", "PartName", repairs_tbl.IdPart);
            return View(repairs_tbl);
        }

        // GET: Repairs_tbl/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Repairs_tbl repairs_tbl = db.Repairs_tbl.Find(id);
            if (repairs_tbl == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCustomer = new SelectList(db.Customers_tbl, "IdCustomer", "Name", repairs_tbl.IdCustomer);
            ViewBag.IdPart = new SelectList(db.Parts_tbl, "IdPart", "PartName", repairs_tbl.IdPart);
            return View(repairs_tbl);
        }

        // POST: Repairs_tbl/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdRepair,IdCustomer,DateOfCarReception,RepairStartDate,Station,RepairEndDate,IdPart,QuantityOfParts,Description,Cost,Discount")] Repairs_tbl repairs_tbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(repairs_tbl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdCustomer = new SelectList(db.Customers_tbl, "IdCustomer", "Name", repairs_tbl.IdCustomer);
            ViewBag.IdPart = new SelectList(db.Parts_tbl, "IdPart", "PartName", repairs_tbl.IdPart);
            return View(repairs_tbl);
        }

        // GET: Repairs_tbl/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Repairs_tbl repairs_tbl = db.Repairs_tbl.Find(id);
            if (repairs_tbl == null)
            {
                return HttpNotFound();
            }
            return View(repairs_tbl);
        }

        // POST: Repairs_tbl/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Repairs_tbl repairs_tbl = db.Repairs_tbl.Find(id);
            db.Repairs_tbl.Remove(repairs_tbl);
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
