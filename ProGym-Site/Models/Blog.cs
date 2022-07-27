namespace ProGym_Site.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;


    [Table("Blog")]
    public partial class Blog
    {
        public int BlogId { get; set; }

        [Required]
        [StringLength(250)]
        public string Baslik { get; set; }

        [Required]
        [StringLength(int.MaxValue,MinimumLength =0,ErrorMessage ="En az 150 karakter olmalý !")]
        public string Icerik { get; set; }

        [StringLength(250)]
        public string ResimURL { get; set; }

        public int? KategoriId { get; set; }

        public virtual Kategori Kategori { get; set; }
    }
}
