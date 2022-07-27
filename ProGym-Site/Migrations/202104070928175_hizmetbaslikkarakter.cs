namespace ProGym_Site.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hizmetbaslikkarakter : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Hizmet", "Aciklama", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Hizmet", "Aciklama", c => c.String(maxLength: 500));
        }
    }
}
