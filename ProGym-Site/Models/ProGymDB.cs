using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;


namespace ProGym_Site.Models
{
    public partial class ProGymDB : DbContext
    {
        public ProGymDB()
        {
        }

        public ProGymDB(string v)
            : base("name=ProGymDB")
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Blog> Blogs { get; set; }
        public virtual DbSet<Hakkimizda> Hakkimizdas { get; set; }
        public virtual DbSet<Hizmet> Hizmets { get; set; }
        public virtual DbSet<Iletisim> Iletisims { get; set; }
        public virtual DbSet<Kategori> Kategoris { get; set; }
        public virtual DbSet<Kimlik> Kimliks { get; set; }
        public virtual DbSet<Slider> Sliders { get; set; }
        public virtual DbSet<Bolum2> Bolum2s { get; set; }
        public virtual DbSet<Bolum3> Bolum3s { get; set; }
       public virtual DbSet<Bolum4> Bolum4s { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //VT þeysi
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<ProGymDB>());
            Database.SetInitializer<ProGymDB>(null);
            //base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<ProGym_Site.Models.Hizmet>();
            base.OnModelCreating(modelBuilder);
        }
    }
}
