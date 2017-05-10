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
    public class Positions_tblController : Controller
    {
        private StoreroomEntities db = new StoreroomEntities();

        // GET: Positions_tbl
        public ActionResult Index()
        {
            return View(db.Positions_tbl.ToList());
        }

        // GET: Positions_tbl/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Positions_tbl positions_tbl = db.Positions_tbl.Find(id);
            if (positions_tbl == null)
            {
                return HttpNotFound();
            }
            return View(positions_tbl);
        }

        // GET: Positions_tbl/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Positions_tbl/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdPosition,Position")] Positions_tbl positions_tbl)
        {
            if (ModelState.IsValid)
            {
                db.Positions_tbl.Add(positions_tbl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(positions_tbl);
        }

        // GET: Positions_tbl/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Positions_tbl positions_tbl = db.Positions_tbl.Find(id);
            if (positions_tbl == null)
            {
                return HttpNotFound();
            }
            return View(positions_tbl);
        }

        // POST: Positions_tbl/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdPosition,Position")] Positions_tbl positions_tbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(positions_tbl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(positions_tbl);
        }

        // GET: Positions_tbl/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Positions_tbl positions_tbl = db.Positions_tbl.Find(id);
            if (positions_tbl == null)
            {
                return HttpNotFound();
            }
            return View(positions_tbl);
        }

        // POST: Positions_tbl/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Positions_tbl positions_tbl = db.Positions_tbl.Find(id);
            db.Positions_tbl.Remove(positions_tbl);
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
