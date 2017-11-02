namespace CleverCSM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class forcedUpdate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "AddressInfoId", "dbo.AddressInfoes");
            DropIndex("dbo.Users", new[] { "AddressInfoId" });
            AddColumn("dbo.Users", "Password", c => c.String(nullable: false));
            AddColumn("dbo.Users", "AddressInfoEmail", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "AddressInfoId", c => c.Int(nullable: false));
            CreateIndex("dbo.Users", "AddressInfoId");
            AddForeignKey("dbo.Users", "AddressInfoId", "dbo.AddressInfoes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "AddressInfoId", "dbo.AddressInfoes");
            DropIndex("dbo.Users", new[] { "AddressInfoId" });
            AlterColumn("dbo.Users", "AddressInfoId", c => c.Int());
            AlterColumn("dbo.Users", "Name", c => c.String());
            DropColumn("dbo.Users", "AddressInfoEmail");
            DropColumn("dbo.Users", "Password");
            CreateIndex("dbo.Users", "AddressInfoId");
            AddForeignKey("dbo.Users", "AddressInfoId", "dbo.AddressInfoes", "Id");
        }
    }
}
