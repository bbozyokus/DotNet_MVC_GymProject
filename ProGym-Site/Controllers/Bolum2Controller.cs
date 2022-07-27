using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProGym_Site.Models;

namespace ProGym_Site.Controllers
{
    public class Bolum2Controller : Controller
    {
        private ProGymDB db = new ProGymDB();

        // GET: Bolum2
        public ActionResult Index()
        {
            return View(db.Bolum2s.ToList());
        }

        // GET: Bolum2/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bolum2 bolum2 = db.Bolum2s.Find(id);
            if (bolum2 == null)
            {
                return HttpNotFound();
            }
            return View(bolum2);
        }

        // POST: Bolum2/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Bolum2Id,Baslik,Madde1Baslik,Madde1icerik,Madde2Baslik,Madde2icerik,Madde3Baslik,Madde3icerik")] Bolum2 bolum2)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bolum2).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bolum2);
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
