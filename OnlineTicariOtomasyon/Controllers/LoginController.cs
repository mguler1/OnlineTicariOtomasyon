using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using OnlineTicariOtomasyon.Models.Sınıflar;

namespace OnlineTicariOtomasyon.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        Context c = new Context();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public PartialViewResult Partial()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult Partial(Cari x)
        {
            c.Caris.Add(x);
            c.SaveChanges();
            return PartialView();
        }
        [HttpGet]
        public ActionResult CariLogin1()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CariLogin1(Cari p)
        {
            var bilgiler = c.Caris.FirstOrDefault(x => x.CariMail == p.CariMail && x.CariSifre == p.CariSifre);
            if (bilgiler!=null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.CariMail, false);
                Session["CariMail"] = bilgiler.CariMail.ToString();
                return RedirectToAction("Index", "Caripanel");
            }
            else
            {
                return RedirectToAction("Index","Login");
            }
           
        }
        [HttpGet]
        public ActionResult AdminLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminLogin(Admin a)
        {
            var admin = c.Admins.FirstOrDefault(x => x.KullaniciAd == a.KullaniciAd && x.Sifre == a.Sifre);
            if (admin !=null)
            {
                FormsAuthentication.SetAuthCookie(admin.KullaniciAd, false);
                Session["KullaniciAd"] = admin.KullaniciAd.ToString();
                return RedirectToAction("Index", "Kategori");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

    }
}