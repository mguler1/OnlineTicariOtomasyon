using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineTicariOtomasyon.Models.Sınıflar
{
    public class Cari
    {
        [Key]
        public int CariID { get; set; }
        [Display(Name ="Cari Adı")]
        [Column(TypeName = "Varchar")]
        [StringLength(30,ErrorMessage ="Ad 30 Karakterden Fazla Olamaz")]
        public string CariAd { get; set; }

        [Display(Name = "Cari Soyadı")]
        [Column(TypeName = "Varchar")]
        [StringLength(30,ErrorMessage = "Ad 30 Karakterden Fazla Olamaz")]
        public string CariSoyad { get; set; }

        [Display(Name = "Şehir")]
        [Column(TypeName = "Varchar")]
        [StringLength(13)]
        public string CariSehir { get; set; }

        [Display(Name = "Mail")]
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string CariMail { get; set; }

        [Display(Name = "Şifre")]
        [Column(TypeName = "Varchar")]
        [StringLength(20)]
        public string CariSifre { get; set; }
        public bool Durum { get; set; }
        public ICollection<SatisHareket> SatisHarekets { get; set; }

    }
}