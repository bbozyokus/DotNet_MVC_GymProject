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
    public class BlogController : Controller
    {
        private ProGymDB db = new ProGymDB();
        // GET: Blog

        public ActionResult Index()
        {
            //db.Configuration.LazyLoadingEnabled = false; //Kategori adı çekerken problem olmaması için.

            return View(db.Blogs.Include("Kategori").ToList().OrderByDescending(x=>x.BlogId));
        }

        public ActionResult Create()
        {
            ViewBag.KategoriId = new SelectList(db.Kategoris, "KategoriId", "KategoriAd");
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Blog blog,HttpPostedFileBase ResimURL)
        {
            try
            {
                if (ResimURL != null)
                {
                    WebImage img = new WebImage(ResimURL.InputStream);
                    FileInfo imginfo = new FileInfo(ResimURL.FileName);

                    string blogimgname = Guid.NewGuid().ToString() + imginfo.Extension;
                    img.Resize(600, 320);
                    img.Save("~/Uploads/Blog/" + blogimgname);

                    blog.ResimURL = "/Uploads/Blog/" + blogimgname;

                }
                db.Blogs.Add(blog);
                db.SaveChanges();
            }
            catch
            {
            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id )
        {
            if (id==null)
            {
                return HttpNotFound();
            }
            var b = db.Blogs.Where(x => x.BlogId == id).SingleOrDefault();
            if (b==null)
            {
                return HttpNotFound();
            }
            ViewBag.KategoriId = new SelectList(db.Kategoris, "KategoriId", "KategoriAd", b.KategoriId);
            return View(b);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(int id, Blog blog,HttpPostedFileBase ResimURL)
        {
            if (ModelState.IsValid)
            {
                var b = db.Blogs.Where(x => x.BlogId == id).SingleOrDefault();

                if (ResimURL != null)
                {
                    if (System.IO.File.Exists(Server.MapPath(b.ResimURL)))
                    {
                        System.IO.File.Delete(Server.MapPath(b.ResimURL));
                    }
                    WebImage img = new WebImage(ResimURL.InputStream);
                    FileInfo imginfo = new FileInfo(ResimURL.FileName);

                    string blogimgname = Guid.NewGuid().ToString() + imginfo.Extension;
                    img.Resize(600, 320); //Logo boyutu ayarlanacak sonra
                    img.Save("~/Uploads/Blog/" + blogimgname);

                    b.ResimURL = "/Uploads/Blog/" + blogimgname;
                }

                b.Baslik = blog.Baslik;
                b.Icerik = blog.Icerik;
                b.KategoriId = blog.KategoriId;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(blog);
        }


        public ActionResult Delete(int id)
        {
            var b = db.Blogs.Find(id);
            if (b==null)
            {
                return HttpNotFound();
            }
            if (System.IO.File.Exists(Server.MapPath(b.ResimURL)))
            {
                System.IO.File.Delete(Server.MapPath(b.ResimURL));
            }
            db.Blogs.Remove(b);
            db.SaveChanges();


            return RedirectToAction("Index");
        }
    }
}