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
    public class productController : Controller
    {
        private Model1 db = new Model1();

        // GET: product
        public ActionResult Index()
        {
            var productTables = db.productTables.Include(p => p.BrandTable).Include(p => p.CategoriTable);
            return View(productTables.ToList());
        }

        // GET: product/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            productTable productTable = db.productTables.Find(id);
            if (productTable == null)
            {
                return HttpNotFound();
            }
            return View(productTable);
        }

        // GET: product/Create
        public ActionResult Create()
        {
            ViewBag.brand_id = new SelectList(db.BrandTables, "id", "Brand");
            ViewBag.categori_id = new SelectList(db.CategoriTables, "id", "Catogori");
            return View();
        }

        // POST: product/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,brand_id,categori_id,quentity,price")] productTable productTable)
        {
            if (ModelState.IsValid)
            {
                db.productTables.Add(productTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.brand_id = new SelectList(db.BrandTables, "id", "Brand", productTable.brand_id);
            ViewBag.categori_id = new SelectList(db.CategoriTables, "id", "Catogori", productTable.categori_id);
            return View(productTable);
        }

        // GET: product/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            productTable productTable = db.productTables.Find(id);
            if (productTable == null)
            {
                return HttpNotFound();
            }
            ViewBag.brand_id = new SelectList(db.BrandTables, "id", "Brand", productTable.brand_id);
            ViewBag.categori_id = new SelectList(db.CategoriTables, "id", "Catogori", productTable.categori_id);
            return View(productTable);
        }

        // POST: product/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,brand_id,categori_id,quentity,price")] productTable productTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.brand_id = new SelectList(db.BrandTables, "id", "Brand", productTable.brand_id);
            ViewBag.categori_id = new SelectList(db.CategoriTables, "id", "Catogori", productTable.categori_id);
            return View(productTable);
        }

        // GET: product/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            productTable productTable = db.productTables.Find(id);
            if (productTable == null)
            {
                return HttpNotFound();
            }
            return View(productTable);
        }

        // POST: product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            productTable productTable = db.productTables.Find(id);
            db.productTables.Remove(productTable);
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
