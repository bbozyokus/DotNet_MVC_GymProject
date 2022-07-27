using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using ProGym_Site.Models;

namespace ProGym_Site.Controllers
{
    public class HakkimizdaController : Controller
    {
        ProGymDB db = new ProGymDB();
        // GET: Hakkimizda
        public ActionResult Index()
        {
            var h = db.Hakkimizdas.ToList();
            return View(h);
        }

        public ActionResult Edit(int id)
        {
            var h = db.Hakkimizdas.Where(x => x.HakkimizdaId == id).FirstOrDefault();
            return View(h);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(int id, Hakkimizda hakkimizda,HttpPostedFileBase ResimURL,HttpPostedFileBase Anagorsel)
        {
            if (ModelState.IsValid)
            {
                var h = db.Hakkimizdas.Where(x => x.HakkimizdaId == id).SingleOrDefault();

                if(ResimURL != null || Anagorsel !=null)
                {

                    WebImage img = new WebImage(Anagorsel.InputStream);
                    WebImage imgresim = new WebImage(ResimURL.InputStream);

                    FileInfo imginfo = new FileInfo(Anagorsel.FileName);
                    FileInfo resiminfo = new FileInfo(ResimURL.FileName);

                    string Anagorselname = Guid.NewGuid().ToString() + imginfo.Extension;
                    string Resimurlname = Guid.NewGuid().ToString() + resiminfo.Extension;

                    img.Resize(1920, 275);
                    imgresim.Resize(227, 427);

                    img.Save("~/Uploads/Hakkimizda/" + Anagorselname);
                    imgresim.Save("~/Uploads/Hakkimizda/" + Resimurlname);

                    h.Anagorsel = ("/Uploads/Hakkimizda/" + Anagorselname);
                    h.ResimURL = ("/Uploads/Hakkimizda/" + Resimurlname);
                }

                h.Aciklama = hakkimizda.Aciklama;
                h.Baslik = hakkimizda.Baslik;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hakkimizda);
        }

    }
}