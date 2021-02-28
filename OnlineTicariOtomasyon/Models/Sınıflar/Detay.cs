using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineTicariOtomasyon.Models.Sınıflar
{
    public class Detay
    {
        [Key]
        public int DetayID { get; set; }
        [Display(Name = "Ürün Adı")]
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string UrunAd { get; set; }
        [Display(Name = "Ürün Bilgisi")]
        [Column(TypeName = "Varchar")]
        [StringLength(2500)]
        public string UrunBilgi { get; set; }
    }
}