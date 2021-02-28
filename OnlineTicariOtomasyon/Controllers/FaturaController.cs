using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineTicariOtomasyon.Models.Sınıflar;
namespace OnlineTicariOtomasyon.Controllers
{
    public class FaturaController : Controller
    {
        // GET: Fatura
        Context c = new Context();
        public ActionResult Index()
        {
            var liste = c.Faturas.ToList();
            return View(liste);
        }
        [HttpGet]
        public ActionResult FaturaEkle(SatisHareket s)
        {
           
            return View();
        }
        [HttpPost]
        public ActionResult FaturaEkle(Fatura f)
        {
          //  s.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            c.Faturas.Add(f);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult FaturaGetir(int id)
        {
            var fatura = c.Faturas.Find(id);
            return View("FaturaGetir", fatura);
        }
        public ActionResult FaturaGuncelle(Fatura fa)
        {
            var dp = c.Faturas.Find(fa.FaturaID);
            dp.FaturaSeriNo = fa.FaturaSeriNo;
            dp.FaturaSıraNo = fa.FaturaSıraNo;
            dp.Tarih = fa.Tarih;
            dp.Saat = fa.Saat;
            dp.VergiDairesi = fa.VergiDairesi;
            dp.TeslimEden = fa.TeslimEden;
            dp.TeslimAlan = fa.TeslimAlan;
            dp.Toplam = fa.Toplam;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult FaturaDetay(int id)
        {
            var degerler = c.FaturaKalems.Where(x => x.Faturaid== id).ToList();
           
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniKalemGiris()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniKalemGiris(FaturaKalem fk)
        {
            c.FaturaKalems.Add(fk);
            c.SaveChanges();
            return View();
        }
        public ActionResult Dinamik()
        {
            Class3 cs = new Class3();
            cs.deger1 = c.Faturas.ToList();
            cs.deger2 = c.FaturaKalems.ToList();
            return View(cs);
        }
    }
}