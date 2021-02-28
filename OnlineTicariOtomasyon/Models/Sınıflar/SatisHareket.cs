using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineTicariOtomasyon.Models.Sınıflar
{
    public class SatisHareket
    {
        [Key]
        public int SatisID { get; set; }
        //ürün
        public virtual Urun Urun { get; set; }
        public int Urunid { get; set; }
        //cari
        public virtual Cari Cari { get; set; }
        public int Cariid { get; set; }
        //personel
        public virtual Personel Personel { get; set; }
        public int Personelid { get; set; }

        public DateTime Tarih { get; set; }
        public int Adet { get; set; }
        public decimal Fiyat { get; set; }
        public decimal ToplamTutar { get; set; }
    }
}