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
    public class PelanggansController : Controller
    {
        private MerchantsContext db = new MerchantsContext();

        // GET: Pelanggans
        public ActionResult Index()
        {
            return View(db.Pelanggans.ToList());
        }

        // GET: Pelanggans/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pelanggan pelanggan = db.Pelanggans.Find(id);
            if (pelanggan == null)
            {
                return HttpNotFound();
            }
            return View(pelanggan);
        }

        // GET: Pelanggans/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pelanggans/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Nama,Alamat,Kelamin,Pekerjaan")] Pelanggan pelanggan)
        {
            if (ModelState.IsValid)
            {
                db.Pelanggans.Add(pelanggan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pelanggan);
        }

        // GET: Pelanggans/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pelanggan pelanggan = db.Pelanggans.Find(id);
            if (pelanggan == null)
            {
                return HttpNotFound();
            }
            return View(pelanggan);
        }

        // POST: Pelanggans/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Nama,Alamat,Kelamin,Pekerjaan")] Pelanggan pelanggan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pelanggan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pelanggan);
        }

        // GET: Pelanggans/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pelanggan pelanggan = db.Pelanggans.Find(id);
            if (pelanggan == null)
            {
                return HttpNotFound();
            }
            return View(pelanggan);
        }

        // POST: Pelanggans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pelanggan pelanggan = db.Pelanggans.Find(id);
            db.Pelanggans.Remove(pelanggan);
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
