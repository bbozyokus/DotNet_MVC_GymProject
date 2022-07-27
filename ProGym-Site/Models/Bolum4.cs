using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProGym_Site.Models
{
    public class Bolum4
    {
        [Key]
        public int Bolum4Id { get; set; }
        //Metabolizma Kısmı

        [StringLength(int.MaxValue)]
        public string FiyatBaslik { get; set; }

        [StringLength(int.MaxValue)]
        public string FiyatAciklama { get; set; }

        [StringLength(int.MaxValue)]
        public string FiyatResim { get; set; }
    }
}