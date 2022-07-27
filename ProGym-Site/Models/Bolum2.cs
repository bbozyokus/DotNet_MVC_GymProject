using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProGym_Site.Models
{
    public class Bolum2
    {
        [Key]
        public int Bolum2Id { get; set; }

        //Bolum2-Başlık
        [DisplayName("AnaSayfa Bölüm2-Başlık"), StringLength(150, ErrorMessage = "150 karakter olmalı !")]

        public string Baslik { get; set; }

        //Bolum2-Madde-1

        [DisplayName("Madde-1 Başlık"), StringLength(30, ErrorMessage = "30 Karakter olmalıdır.")]
        public string Madde1Baslik { get; set; }

        [DisplayName("Madde-1 İçerik"), StringLength(150, ErrorMessage = "150 Karakter olmalıdır.")]
        public string Madde1icerik { get; set; }

        //Bolum2-Madde-2
        [DisplayName("Madde-2 Başlık"), StringLength(30, ErrorMessage = "30 Karakter olmalıdır.")]
        public string Madde2Baslik { get; set; }

        [DisplayName("Madde-2 İçerik"), StringLength(150, ErrorMessage = "150 Karakter olmalıdır.")]
        public string Madde2icerik { get; set; }

        //Bolum2-Madde-3
        [DisplayName("Bölüm 2 Madde-3 Başlık"), StringLength(30, ErrorMessage = "30 Karakter olmalıdır.")]
        public string Madde3Baslik { get; set; }

        [DisplayName("Bölüm 2 Madde-3 İçerik"), StringLength(150, ErrorMessage = "150 Karakter olmalıdır.")]
        public string Madde3icerik { get; set; }

    }
}