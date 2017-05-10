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
    public class Users_tblController : Controller
    {
        private StoreroomEntities db = new StoreroomEntities();

        // GET: Users_tbl
        public ActionResult Index()
        {
            var users_tbl = db.Users_tbl.Include(u => u.Positions_tbl);
            return View(users_tbl.ToList());
        }

        // GET: Users_tbl/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Users_tbl users_tbl = db.Users_tbl.Find(id);
            if (users_tbl == null)
            {
                return HttpNotFound();
            }
            return View(users_tbl);
        }

        // GET: Users_tbl/Create
        public ActionResult Create()
        {
            ViewBag.IdPosition = new SelectList(db.Positions_tbl, "IdPosition", "Position");
            return View();
        }

        // POST: Users_tbl/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdUser,UserName,IdPosition,Permission")] Users_tbl users_tbl)
        {
            if (ModelState.IsValid)
            {
                db.Users_tbl.Add(users_tbl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdPosition = new SelectList(db.Positions_tbl, "IdPosition", "Position", users_tbl.IdPosition);
            return View(users_tbl);
        }

        // GET: Users_tbl/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Users_tbl users_tbl = db.Users_tbl.Find(id);
            if (users_tbl == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdPosition = new SelectList(db.Positions_tbl, "IdPosition", "Position", users_tbl.IdPosition);
            return View(users_tbl);
        }

        // POST: Users_tbl/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdUser,UserName,IdPosition,Permission")] Users_tbl users_tbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(users_tbl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdPosition = new SelectList(db.Positions_tbl, "IdPosition", "Position", users_tbl.IdPosition);
            return View(users_tbl);
        }

        // GET: Users_tbl/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Users_tbl users_tbl = db.Users_tbl.Find(id);
            if (users_tbl == null)
            {
                return HttpNotFound();
            }
            return View(users_tbl);
        }

        // POST: Users_tbl/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Users_tbl users_tbl = db.Users_tbl.Find(id);
            db.Users_tbl.Remove(users_tbl);
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
