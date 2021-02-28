using OnlineTicariOtomasyon.Models.Sınıflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineTicariOtomasyon.Controllers
{
    public class KargoController : Controller
    {
        // GET: Kargo
        Context c = new Context();
        public ActionResult Index(string p)
        {
            var kargo = from x in c.KargoDetays select x;
            if (!string.IsNullOrEmpty(p))
            {
                kargo = kargo.Where(y => y.TakipKodu.Contains(p));
            }
            return View(kargo.ToList());
        }
        [HttpGet]
        public ActionResult YeniKargo()
        {
            Random rnd = new Random();
            string[] karakterker = { "A", "B", "C", "D", "E", "F", "G", };
            int k1, k2, k3;
            k1 = rnd.Next(0, 4);
            k2 = rnd.Next(0, 4);
            k3 = rnd.Next(0, 4);
            int s1, s2, s3;
            s1 = rnd.Next(100, 1000);
            s2 = rnd.Next(10, 99);
            s3 = rnd.Next(10, 99);
            string kod = s1.ToString() + karakterker[k1] + s2 + karakterker[k2] + s3 + karakterker[k3];
            ViewBag.takipkod = kod;
            return View();
        }
        [HttpPost]
        public ActionResult YeniKargo(KargoDetay d)
        {
            c.KargoDetays.Add(d);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult KargoDetay(string id)
        {
            var degerler = c.KargoTakips.Where(x => x.TakipKodu== id).ToList();
           
            return View(degerler);
        }
    }
}