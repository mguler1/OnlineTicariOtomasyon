using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineTicariOtomasyon.Models.Sınıflar;
namespace OnlineTicariOtomasyon.Controllers
{
    public class CariController : Controller
    {
        // GET: Cari
        Context c = new Context();
        public ActionResult Index()
        {
            var cari = c.Caris.Where(x=>x.Durum==true).ToList();
            return View(cari);
        }
        [HttpGet]
        public ActionResult CariEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CariEkle(Cari ca)
        {
            ca.Durum = true;
            c.Caris.Add(ca);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CariSil(int id)
        {
            var cr = c.Caris.Find(id);
            cr.Durum = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CariGetir(int id)
        {
            var ca = c.Caris.Find(id);
            return View("CariGetir", ca);
        }
        public ActionResult CariGuncelle(Cari z)
        {
            var a = c.Caris.Find(z.CariID);
            a.CariAd = z.CariAd;
            a.CariSoyad = z.CariSoyad;
            a.CariSehir = z.CariSehir;
            a.CariMail = z.CariMail;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CariDetay(int id)
        {
            var degerler = c.SatisHarekets.Where(x => x.Cariid == id).ToList();
            var cr = c.Caris.Where(x => x.CariID == id).Select(y => y.CariAd + " " + y.CariSoyad).FirstOrDefault();
            ViewBag.cari = cr;
            return View(degerler);
        }
    }
}