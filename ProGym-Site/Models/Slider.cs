using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProGym_Site.Models
{
    [Table("Slider")]
    public class Slider
    {
        //Bolum1
        [Key]
        public int SliderId { get; set; }
        [DisplayName("Slider Başlık"),StringLength(30,ErrorMessage ="30 karakter olmalı !")]

        public string Baslik { get; set; }

        [DisplayName("Slider Açıklama"),StringLength(150,ErrorMessage ="150 Karakter olmalıdır.")]
        public string Aciklama { get; set; }

        [DisplayName("Slider Resim"),StringLength(250)]
        public string ResimURL { get; set; }


    }
}