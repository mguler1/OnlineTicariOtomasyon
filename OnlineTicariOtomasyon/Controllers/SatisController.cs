using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineTicariOtomasyon.Models.Sınıflar;
namespace OnlineTicariOtomasyon.Controllers
{
    public class SatisController : Controller
    {
        // GET: Satis
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.SatisHarekets.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniSatis()
        {
            List<SelectListItem> deger1 = (from x in c.Uruns.ToList() select new SelectListItem { Text = x.UrunAd, Value = x.UrunID.ToString() }).ToList();
            List<SelectListItem> deger2 = (from x in c.Caris.ToList() select new SelectListItem { Text = x.CariAd+" "+x.CariSoyad, Value = x.CariID.ToString() }).ToList();
            List<SelectListItem> deger3 = (from x in c.Personels.ToList() select new SelectListItem { Text = x.PersonelAd+" "+x.PersonelSoyad, Value = x.PersonelID.ToString() }).ToList();
            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;

            return View();
        }
        [HttpPost]
        public ActionResult YeniSatis(SatisHareket s)
        {
            s.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            c.SatisHarekets.Add(s);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SatisGetir(int id) 
        {
            List<SelectListItem> deger1 = (from x in c.Uruns.ToList() select new SelectListItem { Text = x.UrunAd, Value = x.UrunID.ToString() }).ToList();
            List<SelectListItem> deger2 = (from x in c.Caris.ToList() select new SelectListItem { Text = x.CariAd + " " + x.CariSoyad, Value = x.CariID.ToString() }).ToList();
            List<SelectListItem> deger3 = (from x in c.Personels.ToList() select new SelectListItem { Text = x.PersonelAd + " " + x.PersonelSoyad, Value = x.PersonelID.ToString() }).ToList();
            ViewBag.dgr1 = deger1;
            ViewBag.dgr2 = deger2;
            ViewBag.dgr3 = deger3;
            var satis = c.SatisHarekets.Find(id);
            return View("SatisGetir", satis);
        }
        public ActionResult SatisGuncelle(SatisHareket sh)
        {
            var a = c.SatisHarekets.Find(sh.SatisID);
            a.Tarih = sh.Tarih;
            a.Adet = sh.Adet;
            a.Fiyat = sh.Fiyat;
            a.ToplamTutar = sh.ToplamTutar;
            a.Personelid = sh.Personelid;
            a.Urunid = sh.Urunid;
            a.Cariid = sh.Cariid;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SatisDetay(int id)
        {
            var degerler = c.SatisHarekets.Where(x => x.SatisID == id).ToList();

            return View(degerler);
        }
    }
}