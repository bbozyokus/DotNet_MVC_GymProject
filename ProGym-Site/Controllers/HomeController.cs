using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProGym_Site.Models;
using PagedList;
using PagedList.Mvc;

namespace ProGym_Site.Controllers
{
    public class HomeController : Controller
    {
        private ProGymDB db = new ProGymDB();
        
        // GET: Home
        [Route("")]
        [Route("Anasayfa")]
        public ActionResult Index()
        {
            ViewBag.Kimlik = db.Kimliks.SingleOrDefault();
            //ViewBag.Hizmetler = db.Hizmets.ToList().OrderByDescending(x => x.HizmetId);
            return View();
        }

        public ActionResult AnaGorsel()
        {
            ViewBag.Kimlik = db.Kimliks.SingleOrDefault();
            return View(db.Sliders.SingleOrDefault());
        }

        public ActionResult Bolum2Partial()
        {
            ViewBag.Kimlik = db.Kimliks.SingleOrDefault();
            return View(db.Bolum2s.SingleOrDefault());
        }

        public ActionResult Bolum3Partial()
        {
            ViewBag.Kimlik = db.Kimliks.SingleOrDefault();
            return View(db.Bolum3s.SingleOrDefault());
        }

        //Anasayfa kısmı bitti..
        [Route("SSS")]
        public ActionResult Salonumuz()
        {
            ViewBag.Kimlik = db.Kimliks.SingleOrDefault();
            return View(db.Hizmets.ToList());
        }

        [Route("FiyatBilgisi")]
        public ActionResult FiyatBilgisi()
        {
            ViewBag.Kimlik = db.Kimliks.SingleOrDefault();
            return View(db.Bolum4s.SingleOrDefault());
        }

        [Route("Hakkimizda")]
        public ActionResult Hakkimizda()
        {
            ViewBag.Kimlik = db.Kimliks.SingleOrDefault();
            return View(db.Hakkimizdas.SingleOrDefault());
        }

        public ActionResult Footer()
        {
            ViewBag.Kimlik = db.Kimliks.SingleOrDefault();
            return View(db.Iletisims.SingleOrDefault());
        }

        public ActionResult Header()
        {
            ViewBag.Kimlik = db.Kimliks.SingleOrDefault();
            return View(db.Iletisims.SingleOrDefault());
        }
        [Route("Iletisim")]
        public ActionResult Iletisim()
        {
            ViewBag.Kimlik = db.Kimliks.SingleOrDefault();
            return View(db.Iletisims.SingleOrDefault());
        }
        [Route("BlogPost")]
        public ActionResult Blog(int Page=1)
        {
            ViewBag.Kimlik = db.Kimliks.SingleOrDefault();
            return View(db.Blogs.Include("Kategori").OrderByDescending(x => x.BlogId).ToPagedList(Page,5));
        }
        [Route("BlogPost/{kategoriad}/{id:int}")]
        public ActionResult KategoriBlog(int id,int Page=1)
        {
            ViewBag.Kimlik = db.Kimliks.SingleOrDefault();
            var b = db.Blogs.Include("Kategori").OrderByDescending(x=>x.BlogId).Where(x => x.Kategori.KategoriId == id).ToPagedList(Page,5);
            return View(b);
        }
        [Route("BlogPost/{baslik}-{id:int}")]
        public ActionResult BlogDetay(int id)
        {
            ViewBag.Kimlik = db.Kimliks.SingleOrDefault();
            var b = db.Blogs.Include("Kategori").Where(x => x.BlogId == id).SingleOrDefault();
            return View(b);
        }

        public ActionResult BlogKategoriPartial()
        {
            ViewBag.Kimlik = db.Kimliks.SingleOrDefault();
            //db.Configuration.LazyLoadingEnabled = false;
            return PartialView(db.Kategoris.Include("Blogs").ToList().OrderBy(x => x.KategoriAd));
        }

        public ActionResult BlogKayitPartial()
        {
            ViewBag.Kimlik = db.Kimliks.SingleOrDefault();
            return PartialView(db.Blogs.ToList().OrderByDescending(x => x.BlogId));
        }

    }
}