using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using ProGym_Site.Models;


namespace ProGym_Site.Controllers
{
    public class AdminController : Controller
    {
        ProGymDB db = new ProGymDB();
        // GET: Admin
        //Burada bi sorun olabilir tekrar bak.
        [Route("yonetimpaneli")]
        public ActionResult Index()
        {
            ViewBag.BlogSay = db.Blogs.Count();
            ViewBag.KategoriSay = db.Kategoris.Count();
            ViewBag.HizmetSay = db.Hizmets.Count();

            var sorgu = db.Kategoris.ToList();
            return View(sorgu);
        }

        [Route("yonetimpaneli/giris")]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Admin admin)
        {
            //var md5pass = Crypto.Hash(sifre, "MD5");

            var login = db.Admins.Where(x => x.Eposta == admin.Eposta).SingleOrDefault();

            if (login!=null)
            {
                if (login.Eposta == admin.Eposta && login.Sifre == Crypto.Hash(admin.Sifre,"MD5"))
                {
                    Session["adminid"] = login.AdminId;
                    Session["eposta"] = login.Eposta;
                    return RedirectToAction("Index", "Admin");
                }
                else
                    ViewBag.Uyari = "Kullanıcı adı veya şifre yanlış !";
            }
            else
                ViewBag.Uyari = "Kullanıcı adı veya şifre yanlış !";
            return View(login);
        }

        public ActionResult Logout()
        {
            Session["adminid"] = null;
            Session["eposta"] = null;
            Session.Abandon();
            return RedirectToAction("Login","Admin");
        }

        public ActionResult Adminler()
        {
            return View(db.Admins.ToList());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Admin admin, string sifre, string eposta)
        {
            if (ModelState.IsValid)
            {
                admin.Sifre = Crypto.Hash(sifre, "MD5");
                db.Admins.Add(admin);
                db.SaveChanges();
                return RedirectToAction("Adminler");
            }

            return View(admin);
        }

        public ActionResult Edit(int id)
        {
            var a = db.Admins.Where(x=>x.AdminId == id).SingleOrDefault();
            return View(a);
        }

        [HttpPost]
        public ActionResult Edit(int id,Admin admin,string sifre,string eposta)
        {
            if (ModelState.IsValid)
            {
                var a = db.Admins.Where(x => x.AdminId == id).SingleOrDefault();
                a.Sifre = Crypto.Hash(sifre, "MD5");
                a.Eposta = admin.Eposta;
                a.Yetki = admin.Yetki;
                db.SaveChanges();
            }
            return View(admin);
        }

        public ActionResult Delete(int id)
        {
            var a = db.Admins.Where(x => x.AdminId == id).SingleOrDefault();

            if (a != null)
            {
                db.Admins.Remove(a);
                db.SaveChanges();
                return RedirectToAction("Adminler");
            }
            return View();
        }

        public ActionResult SifremiUnuttum()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SifremiUnuttum(string eposta)
        {
            var mail = db.Admins.Where(x => x.Eposta == eposta).SingleOrDefault();
            if (mail!=null)
            {
                Random rnd = new Random();
                int yenisifre = rnd.Next();

                Admin admin = new Admin();
                mail.Sifre = Crypto.Hash(Convert.ToString(yenisifre), "MD5");
                db.SaveChanges();

                WebMail.SmtpServer = "smtp.gmail.com";
                WebMail.EnableSsl = true;
                WebMail.UserName = "mail@asdf.com";
                WebMail.Password = "pass";
                WebMail.SmtpPort = 587;
                WebMail.Send(eposta,"Admin panel giriş Şifreniz", "Şifreniz: "+yenisifre);
                ViewBag.Uyari = "Mail başarıyla gönderildi.";
            }
            else
            {
                ViewBag.Uyari = "Hata Oluştu. Tekrar Deneyin";
            }

            return View();
        }

    }
}