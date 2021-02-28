using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineTicariOtomasyon.Models.Sınıflar
{
    public class Kategori
    {
        [Key]
        public int KategoriD { get; set; }

        [Display(Name = "Kategori Adı")]
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string KategoriAd { get; set; }
        public ICollection<Urun> Uruns { get; set; }//her kategoride birden fazla ürün olabilir
    }
}