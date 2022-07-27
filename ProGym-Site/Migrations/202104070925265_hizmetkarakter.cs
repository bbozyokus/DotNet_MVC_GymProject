namespace ProGym_Site.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hizmetkarakter : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Hizmet", "Baslik", c => c.String(nullable: false, maxLength: 350));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Hizmet", "Baslik", c => c.String(nullable: false, maxLength: 50));
        }
    }
}
