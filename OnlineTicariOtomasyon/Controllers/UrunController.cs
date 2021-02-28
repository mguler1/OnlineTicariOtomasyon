using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineTicariOtomasyon.Models.Sınıflar;
namespace OnlineTicariOtomasyon.Controllers
{
    public class UrunController : Controller
    {

        // GET: Urun
        Context c = new Context();
        public ActionResult Index(string p )
        {
            var urunler = from x in c.Uruns select x;
            if (!string.IsNullOrEmpty(p))
            {
                urunler = urunler.Where(y => y.UrunAd.Contains(p));
            }
            return View(urunler.ToList());
        }
        [HttpGet]
        public ActionResult YeniUrun()
        {
            //katgeori isimlerini dropdown liste çekme
            List<SelectListItem> deger1 = (from x in c.Kategoris.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.KategoriAd,
                                               Value = x.KategoriD.ToString()

                                           }).ToList();
            ViewBag.dgr1 = deger1;
            return View();
        }
        [HttpPost]
        public ActionResult YeniUrun(Urun p)
        {
            c.Uruns.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunSil(int id)
        {
            var urn = c.Uruns.Find(id);
            c.Uruns.Remove(urn);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunGetir(int id)
        {
            List<SelectListItem> deger1 = (from x in c.Kategoris.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.KategoriAd,
                                               Value = x.KategoriD.ToString()

                                           }).ToList();
            ViewBag.dgr1 = deger1;
            var urunDeger = c.Uruns.Find(id);
            return View("UrunGetir",urunDeger);
        }
        public ActionResult UrunGuncelle(Urun p )
        {
            var urn = c.Uruns.Find(p.UrunID);
            urn.AlisFiyat = p.AlisFiyat;
            urn.Durum = p.Durum;
            urn.Kategori.KategoriD = p.Kategori.KategoriD;
            urn.Marka = p.Marka;
            urn.SatisFiyat = p.SatisFiyat;
            urn.Stok = p.Stok;
            urn.UrunAd = p.UrunAd;
            urn.UrunGorsel = p.UrunGorsel;
            c.SaveChanges();
               
            return RedirectToAction("Index");
        }
        public ActionResult UrunListesi()
        {
            var degerler = c.Uruns.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult SatisYap(int id )
        {
            List<SelectListItem> deger3 = (from x in c.Personels.ToList() select new SelectListItem { Text = x.PersonelAd + " " + x.PersonelSoyad, Value = x.PersonelID.ToString() }).ToList();
            ViewBag.dgr3 = deger3;
            var deger1 = c.Uruns.Find(id);
            ViewBag.dgr1 = deger1.UrunID;
            ViewBag.dgr2 = deger1.SatisFiyat;

            return View();
        }
        [HttpPost]
        public ActionResult SatisYap(SatisHareket s )
        {
            s.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            c.SatisHarekets.Add(s);
            c.SaveChanges();
            return RedirectToAction("Index","Satis");
    
        }
    }
}