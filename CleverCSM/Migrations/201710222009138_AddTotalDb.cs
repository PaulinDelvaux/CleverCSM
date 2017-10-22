namespace CleverCSM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTotalDb : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contacts", "CustomerId", c => c.Int(nullable: false));
            DropColumn("dbo.Contacts", "ConnectId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Contacts", "ConnectId", c => c.Int(nullable: false));
            DropColumn("dbo.Contacts", "CustomerId");
        }
    }
}
