using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProGym_Site.Models
{
    public class Bolum3
    {
        [Key]
        public int Bolum3Id { get; set; }
        //Sayfa - Bolum-3

        [DisplayName("Bölüm 3 Başlık"), StringLength(30, ErrorMessage = "30 karakter olmalı !")]
        public string Bolum3Baslik { get; set; }


        [DisplayName("Açıklama-1"), StringLength(150, ErrorMessage = "150 Karakter olmalıdır.")]
        public string Aciklama1 { get; set; }

        [DisplayName("Açıklama-2"), StringLength(150, ErrorMessage = "150 Karakter olmalıdır.")]
        public string Aciklama2 { get; set; }

        [DisplayName("Açıklama-3"), StringLength(150, ErrorMessage = "150 Karakter olmalıdır.")]
        public string Aciklama3 { get; set; }

        [DisplayName("Açıklama-4"), StringLength(150, ErrorMessage = "150 Karakter olmalıdır.")]
        public string Aciklama4 { get; set; }

        [DisplayName("Açıklama-5"), StringLength(150, ErrorMessage = "150 Karakter olmalıdır.")]
        public string Aciklama5 { get; set; }

        [DisplayName("Açıklama-6"), StringLength(150, ErrorMessage = "150 Karakter olmalıdır.")]
        public string Aciklama6 { get; set; }




        [DisplayName("Slider Resim"), StringLength(250)]
        public string ResimURL2 { get; set; }
    }
}