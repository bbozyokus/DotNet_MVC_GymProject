namespace ProGym_Site.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Bolum3ColumnUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bolum3", "Aciklama4", c => c.String(maxLength: 150));
            AddColumn("dbo.Bolum3", "Aciklama5", c => c.String(maxLength: 150));
            AddColumn("dbo.Bolum3", "Aciklama6", c => c.String(maxLength: 150));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Bolum3", "Aciklama6");
            DropColumn("dbo.Bolum3", "Aciklama5");
            DropColumn("dbo.Bolum3", "Aciklama4");
        }
    }
}
