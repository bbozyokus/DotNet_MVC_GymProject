namespace ProGym_Site.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbfiyat : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bolum4", "FiyatBaslik", c => c.String());
            AddColumn("dbo.Bolum4", "FiyatAciklama", c => c.String());
            AddColumn("dbo.Bolum4", "FiyatResim", c => c.String());
            DropColumn("dbo.Bolum4", "MetabolizmaBaslik");
            DropColumn("dbo.Bolum4", "MetabolizmaAciklama");
            DropColumn("dbo.Bolum4", "MetabolizmaResim");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Bolum4", "MetabolizmaResim", c => c.String(maxLength: 250));
            AddColumn("dbo.Bolum4", "MetabolizmaAciklama", c => c.String(maxLength: 150));
            AddColumn("dbo.Bolum4", "MetabolizmaBaslik", c => c.String(maxLength: 30));
            DropColumn("dbo.Bolum4", "FiyatResim");
            DropColumn("dbo.Bolum4", "FiyatAciklama");
            DropColumn("dbo.Bolum4", "FiyatBaslik");
        }
    }
}
