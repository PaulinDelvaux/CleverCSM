namespace CleverCSM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddConnectIdToCustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contacts", "ConnectId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contacts", "ConnectId");
        }
    }
}
