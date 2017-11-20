namespace CleverCSM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class requiredMail : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AddressInfoes", "Email", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AddressInfoes", "Email", c => c.String());
        }
    }
}
