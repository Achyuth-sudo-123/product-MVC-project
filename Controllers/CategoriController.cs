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
    public class CategoriController : Controller
    {
        private Model1 db = new Model1();

        // GET: Categori
        public ActionResult Index()
        {
            return View(db.CategoriTables.ToList());
        }

        // GET: Categori/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoriTable categoriTable = db.CategoriTables.Find(id);
            if (categoriTable == null)
            {
                return HttpNotFound();
            }
            return View(categoriTable);
        }

        // GET: Categori/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categori/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Catogori")] CategoriTable categoriTable)
        {
            if (ModelState.IsValid)
            {
                db.CategoriTables.Add(categoriTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(categoriTable);
        }

        // GET: Categori/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoriTable categoriTable = db.CategoriTables.Find(id);
            if (categoriTable == null)
            {
                return HttpNotFound();
            }
            return View(categoriTable);
        }

        // POST: Categori/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Catogori")] CategoriTable categoriTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(categoriTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(categoriTable);
        }

        // GET: Categori/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoriTable categoriTable = db.CategoriTables.Find(id);
            if (categoriTable == null)
            {
                return HttpNotFound();
            }
            return View(categoriTable);
        }

        // POST: Categori/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CategoriTable categoriTable = db.CategoriTables.Find(id);
            db.CategoriTables.Remove(categoriTable);
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
