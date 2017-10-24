namespace CleverCSM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class foreingkeys : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Companies", "AddressInfoId", c => c.Int());
            AddColumn("dbo.Contacts", "AddressInfoId", c => c.Int());
            AddColumn("dbo.Customers", "AddressInfoId", c => c.Int());
            AddColumn("dbo.Users", "AddressInfoId", c => c.Int());
            CreateIndex("dbo.Companies", "AddressInfoId");
            CreateIndex("dbo.Contacts", "AddressInfoId");
            CreateIndex("dbo.Customers", "AddressInfoId");
            CreateIndex("dbo.Users", "AddressInfoId");
            AddForeignKey("dbo.Companies", "AddressInfoId", "dbo.AddressInfoes", "Id");
            AddForeignKey("dbo.Contacts", "AddressInfoId", "dbo.AddressInfoes", "Id");
            AddForeignKey("dbo.Customers", "AddressInfoId", "dbo.AddressInfoes", "Id");
            AddForeignKey("dbo.Users", "AddressInfoId", "dbo.AddressInfoes", "Id");
            DropColumn("dbo.AddressInfoes", "InfoType");
            DropColumn("dbo.AddressInfoes", "InfoTypeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AddressInfoes", "InfoTypeId", c => c.Byte(nullable: false));
            AddColumn("dbo.AddressInfoes", "InfoType", c => c.Byte(nullable: false));
            DropForeignKey("dbo.Users", "AddressInfoId", "dbo.AddressInfoes");
            DropForeignKey("dbo.Customers", "AddressInfoId", "dbo.AddressInfoes");
            DropForeignKey("dbo.Contacts", "AddressInfoId", "dbo.AddressInfoes");
            DropForeignKey("dbo.Companies", "AddressInfoId", "dbo.AddressInfoes");
            DropIndex("dbo.Users", new[] { "AddressInfoId" });
            DropIndex("dbo.Customers", new[] { "AddressInfoId" });
            DropIndex("dbo.Contacts", new[] { "AddressInfoId" });
            DropIndex("dbo.Companies", new[] { "AddressInfoId" });
            DropColumn("dbo.Users", "AddressInfoId");
            DropColumn("dbo.Customers", "AddressInfoId");
            DropColumn("dbo.Contacts", "AddressInfoId");
            DropColumn("dbo.Companies", "AddressInfoId");
        }
    }
}
