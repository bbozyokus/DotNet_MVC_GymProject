namespace ProGym_Site.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Hakkimizda")]
    public partial class Hakkimizda
    {
        public int HakkimizdaId { get; set; }

        [Required]
        [StringLength(50)]
        public string Baslik { get; set; }

        [Required]
        public string Aciklama { get; set; }

        [StringLength(500)]
        public string Anagorsel { get; set; }

        [StringLength(500)]
        public string ResimURL { get; set; }
    }
}
