using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProGym_Site.Models;
using System.IO;
using System.Web.Helpers;

namespace ProGym_Site.Controllers
{
    public class Bolum4Controller : Controller
    {
        private ProGymDB db = new ProGymDB();

        // GET: Bolum4
        public ActionResult Index()
        {
            return View(db.Bolum4s.ToList());
        }

        // GET: Bolum4/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bolum4 bolum4 = db.Bolum4s.Find(id);
            if (bolum4 == null)
            {
                return HttpNotFound();
            }
            return View(bolum4);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        //public ActionResult Edit([Bind(Include = "Bolum4Id,FiyatBaslik,FiyatAciklama,FiyatResim")] Bolum4 bolum4,HttpPostedFileBase ResimURL,HttpPostedFileBase Anagorsel)

        public ActionResult Edit([Bind(Include = "Bolum4Id,FiyatBaslik,FiyatAciklama,FiyatResim")] Bolum4 bolum4, HttpPostedFileBase FiyatResim,int id)
        {
            if (ModelState.IsValid)
            {
                var h = db.Bolum4s.Where(x => x.Bolum4Id == id).SingleOrDefault();

                if(FiyatResim!=null)
                {
                    if (System.IO.File.Exists(Server.MapPath(h.FiyatResim)))
                    {
                        System.IO.File.Delete(Server.MapPath(h.FiyatResim));
                    }

                    WebImage img = new WebImage(FiyatResim.InputStream);
                    FileInfo imginfo = new FileInfo(FiyatResim.FileName);

                    string ResimURLname = Guid.NewGuid().ToString() + imginfo.Extension;
                    img.Resize(900, 900);
                    img.Save("~/Uploads/Bolum4/" +ResimURLname);

                    h.FiyatResim = "/Uploads/Bolum4/" + ResimURLname;
                }
                h.FiyatBaslik = bolum4.FiyatBaslik;
                h.FiyatAciklama = bolum4.FiyatAciklama;

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bolum4);
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
