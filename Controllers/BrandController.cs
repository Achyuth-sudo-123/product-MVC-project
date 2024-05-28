using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using productMVCproject.Models;

namespace productMVCproject.Controllers
{
    public class BrandController : Controller
    {
        private Model1 db = new Model1();

        // GET: Brand
        public ActionResult Index()
        {
            return View(db.BrandTables.ToList());
        }

        // GET: Brand/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BrandTable brandTable = db.BrandTables.Find(id);
            if (brandTable == null)
            {
                return HttpNotFound();
            }
            return View(brandTable);
        }

        // GET: Brand/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Brand/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Brand")] BrandTable brandTable)
        {
            if (ModelState.IsValid)
            {
                db.BrandTables.Add(brandTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(brandTable);
        }

        // GET: Brand/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BrandTable brandTable = db.BrandTables.Find(id);
            if (brandTable == null)
            {
                return HttpNotFound();
            }
            return View(brandTable);
        }

        // POST: Brand/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Brand")] BrandTable brandTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(brandTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(brandTable);
        }

        // GET: Brand/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BrandTable brandTable = db.BrandTables.Find(id);
            if (brandTable == null)
            {
                return HttpNotFound();
            }
            return View(brandTable);
        }

        // POST: Brand/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BrandTable brandTable = db.BrandTables.Find(id);
            db.BrandTables.Remove(brandTable);
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
