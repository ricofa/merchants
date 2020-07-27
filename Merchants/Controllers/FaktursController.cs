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
    public class FaktursController : Controller
    {
        private MerchantsContext db = new MerchantsContext();

        // GET: Fakturs
        public ActionResult Index()
        {
            var fakturs = db.Fakturs.Include(f => f.Karyawan).Include(f => f.Cloth).Include(f => f.Pelanggan);
            return View(fakturs.ToList());
        }

        // GET: Fakturs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Faktur faktur = db.Fakturs.Find(id);
            if (faktur == null)
            {
                return HttpNotFound();
            }
            return View(faktur);
        }

        // GET: Fakturs/Create
        public ActionResult Create()
        {
            ViewBag.KaryawanID = new SelectList(db.Karyawans, "ID", "Nama");
            ViewBag.KaoID = new SelectList(db.Cloths, "ID", "Merk");
            ViewBag.PelangganID = new SelectList(db.Pelanggans, "ID", "Nama");
            return View();
        }

        // POST: Fakturs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Tanggal,Jumlah,Harga,Pajak,Total,PelangganID,KaoID,KaryawanID")] Faktur faktur)
        {
            if (ModelState.IsValid)
            {
                db.Fakturs.Add(faktur);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.KaryawanID = new SelectList(db.Karyawans, "ID", "Nama", faktur.KaryawanID);
            ViewBag.ClothID = new SelectList(db.Cloths, "ID", "Merk", faktur.KaoID);
            ViewBag.PelangganID = new SelectList(db.Pelanggans, "ID", "Nama", faktur.PelangganID);
            return View(faktur);
        }

        // GET: Fakturs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Faktur faktur = db.Fakturs.Find(id);
            if (faktur == null)
            {
                return HttpNotFound();
            }
            ViewBag.KaryawanID = new SelectList(db.Karyawans, "ID", "Nama", faktur.KaryawanID);
            ViewBag.ClothID = new SelectList(db.Cloths, "ID", "Merk", faktur.KaoID);
            ViewBag.PelangganID = new SelectList(db.Pelanggans, "ID", "Nama", faktur.PelangganID);
            return View(faktur);
        }

        // POST: Fakturs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Tanggal,Jumlah,Harga,Pajak,Total,PelangganID,KaoID,KaryawanID")] Faktur faktur)
        {
            if (ModelState.IsValid)
            {
                db.Entry(faktur).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.KaryawanID = new SelectList(db.Karyawans, "ID", "Nama", faktur.KaryawanID);
            ViewBag.ClothID = new SelectList(db.Cloths, "ID", "Merk", faktur.KaoID);
            ViewBag.PelangganID = new SelectList(db.Pelanggans, "ID", "Nama", faktur.PelangganID);
            return View(faktur);
        }

        // GET: Fakturs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Faktur faktur = db.Fakturs.Find(id);
            if (faktur == null)
            {
                return HttpNotFound();
            }
            return View(faktur);
        }

        // POST: Fakturs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Faktur faktur = db.Fakturs.Find(id);
            db.Fakturs.Remove(faktur);
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
