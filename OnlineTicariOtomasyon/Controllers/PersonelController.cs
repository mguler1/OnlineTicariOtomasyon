using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineTicariOtomasyon.Models.Sınıflar;
namespace OnlineTicariOtomasyon.Controllers
{
    public class PersonelController : Controller
    {
        // GET: Personel
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.Personels.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult PersonelEkle()
        {
            List<SelectListItem> deger1 = (from x in c.Departmans.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.DepartmanAd,
                                               Value = x.DepartmanID.ToString()

                                           }).ToList();
            ViewBag.dgr1 = deger1;
            return View();
            
        }
        [HttpPost]
        public ActionResult PersonelEkle(Personel pe)
        {
            //Personel resim ekleme
            if (Request.Files.Count>0)
            {
                string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/image/"+dosyaadi+uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                pe.PersonelGorsel = "/image/"+dosyaadi+uzanti;
            }
            c.Personels.Add(pe);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult PersonelGetir(int id)
        {
            List<SelectListItem> deger1 = (from x in c.Departmans.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.DepartmanAd,
                                               Value = x.DepartmanID.ToString()

                                           }).ToList();
            ViewBag.dgr1 = deger1;
            var ca = c.Personels.Find(id);
            return View("PersonelGetir", ca);
        }
        public ActionResult PersonelGuncelle(Personel k)
        {
            if (Request.Files.Count > 0)
            {
                string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/image/" + dosyaadi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                k.PersonelGorsel = "/image/" + dosyaadi + uzanti;
            }
            var a = c.Personels.Find(k.PersonelID);
            a.PersonelAd = k.PersonelAd;
            a.PersonelSoyad = k.PersonelSoyad;
            a.PersonelGorsel = k.PersonelGorsel;
            a.departmanid = k.departmanid;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult PersonelList()
        {
            var sorgu = c.Personels.ToList();
            return View(sorgu);
        }
        public ActionResult PersonelSil(int id)
        {
            var per = c.Personels.Find(id);
            c.Personels.Remove(per);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
   