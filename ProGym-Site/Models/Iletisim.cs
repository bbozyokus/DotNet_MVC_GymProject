namespace ProGym_Site.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Iletisim")]
    public partial class Iletisim
    {
        public int IletisimId { get; set; }

        [Required]
        public string Adres { get; set; }

        [StringLength(50)]
        public string Tel { get; set; }

        public string Facebook { get; set; }

        [StringLength(50)]
        public string Twitter { get; set; }

        [StringLength(50)]
        public string Instagram { get; set; }

        [StringLength(50)]
        public string Email { get; set; }
    }
}
