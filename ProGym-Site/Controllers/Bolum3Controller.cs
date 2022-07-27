using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using ProGym_Site.Models;

namespace ProGym_Site.Controllers
{
    public class Bolum3Controller : Controller
    {
        private ProGymDB db = new ProGymDB();

        // GET: Bolum3
        public ActionResult Index()
        {
            return View(db.Bolum3s.ToList());
        }

        // GET: Bolum3/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bolum3 bolum3 = db.Bolum3s.Find(id);
            if (bolum3 == null)
            {
                return HttpNotFound();
            }
            return View(bolum3);
        }


        // GET: Bolum3/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bolum3 bolum3 = db.Bolum3s.Find(id);
            if (bolum3 == null)
            {
                return HttpNotFound();
            }
            return View(bolum3);
        }

        // POST: Bolum3/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Bolum3Id,Bolum3Baslik,Aciklama1,Aciklama2,Aciklama3,Aciklama4,Aciklama5,Aciklama6")] Bolum3 bolum3,HttpPostedFileBase ResimURL2,int id)
        {
            if (ModelState.IsValid)
            {
                var b = db.Bolum3s.Where(x => x.Bolum3Id == id).SingleOrDefault();

                if (ResimURL2 != null)
                {
                    if (System.IO.File.Exists(Server.MapPath(b.ResimURL2)))
                    {
                        System.IO.File.Delete(Server.MapPath(b.ResimURL2));
                    }

                    WebImage img = new WebImage(ResimURL2.InputStream);
                    FileInfo imginfo = new FileInfo(ResimURL2.FileName);

                    string bolum3imgname = Guid.NewGuid().ToString() + imginfo.Extension;
                    img.Resize(1920, 616);
                    img.Save("~/Uploads/Bolum3/" + bolum3imgname);

                    b.ResimURL2 = "/Uploads/Bolum3/" + bolum3imgname;

                }
                b.Bolum3Baslik = bolum3.Bolum3Baslik;
                b.Aciklama1 = bolum3.Aciklama1;
                b.Aciklama2 = bolum3.Aciklama2;
                b.Aciklama3 = bolum3.Aciklama3;
                b.Aciklama4 = bolum3.Aciklama4;
                b.Aciklama5 = bolum3.Aciklama5;
                b.Aciklama6 = bolum3.Aciklama6;

                db.Entry(b).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bolum3);
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
