using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Merchants.DAL;
using Merchants.Models;

namespace Merchants.Controllers
{
    public class KaryawansController : Controller
    {
        private MerchantsContext db = new MerchantsContext();

        // GET: Karyawans
        public ActionResult Index()
        {
            var karyawans = db.Karyawans.Include(k => k.Supplier);
            return View(karyawans.ToList());
        }

        // GET: Karyawans/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Karyawan karyawan = db.Karyawans.Find(id);
            if (karyawan == null)
            {
                return HttpNotFound();
            }
            return View(karyawan);
        }

        // GET: Karyawans/Create
        public ActionResult Create()
        {
            ViewBag.SupplierID = new SelectList(db.Suppliers, "ID", "Nama");
            return View();
        }

        // POST: Karyawans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nama,Alamat,Status,Telepon,SupplierID")] Karyawan karyawan)
        {
            if (ModelState.IsValid)
            {
                db.Karyawans.Add(karyawan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SupplierID = new SelectList(db.Suppliers, "ID", "Nama", karyawan.SupplierID);
            return View(karyawan);
        }

        // GET: Karyawans/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Karyawan karyawan = db.Karyawans.Find(id);
            if (karyawan == null)
            {
                return HttpNotFound();
            }
            ViewBag.SupplierID = new SelectList(db.Suppliers, "ID", "Nama", karyawan.SupplierID);
            return View(karyawan);
        }

        // POST: Karyawans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nama,Alamat,Status,Telepon,SupplierID")] Karyawan karyawan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(karyawan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SupplierID = new SelectList(db.Suppliers, "ID", "Nama", karyawan.SupplierID);
            return View(karyawan);
        }

        // GET: Karyawans/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Karyawan karyawan = db.Karyawans.Find(id);
            if (karyawan == null)
            {
                return HttpNotFound();
            }
            return View(karyawan);
        }

        // POST: Karyawans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Karyawan karyawan = db.Karyawans.Find(id);
            db.Karyawans.Remove(karyawan);
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
