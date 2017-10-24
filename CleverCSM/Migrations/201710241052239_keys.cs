namespace CleverCSM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class keys : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Contacts", "CustomerId");
            CreateIndex("dbo.Emails", "ContactId");
            CreateIndex("dbo.Exchanges", "UserId");
            CreateIndex("dbo.Exchanges", "ContactId");
            CreateIndex("dbo.Users", "CompanyId");
            CreateIndex("dbo.Messages", "ExchangeId");
            AddForeignKey("dbo.Contacts", "CustomerId", "dbo.Customers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Emails", "ContactId", "dbo.Contacts", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Exchanges", "ContactId", "dbo.Contacts", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Users", "CompanyId", "dbo.Companies", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Exchanges", "UserId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Messages", "ExchangeId", "dbo.Exchanges", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Messages", "ExchangeId", "dbo.Exchanges");
            DropForeignKey("dbo.Exchanges", "UserId", "dbo.Users");
            DropForeignKey("dbo.Users", "CompanyId", "dbo.Companies");
            DropForeignKey("dbo.Exchanges", "ContactId", "dbo.Contacts");
            DropForeignKey("dbo.Emails", "ContactId", "dbo.Contacts");
            DropForeignKey("dbo.Contacts", "CustomerId", "dbo.Customers");
            DropIndex("dbo.Messages", new[] { "ExchangeId" });
            DropIndex("dbo.Users", new[] { "CompanyId" });
            DropIndex("dbo.Exchanges", new[] { "ContactId" });
            DropIndex("dbo.Exchanges", new[] { "UserId" });
            DropIndex("dbo.Emails", new[] { "ContactId" });
            DropIndex("dbo.Contacts", new[] { "CustomerId" });
        }
    }
}
