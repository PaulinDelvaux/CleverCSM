namespace CleverCSM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDbs : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AddressInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        InfoType = c.Byte(nullable: false),
                        InfoTypeId = c.Byte(nullable: false),
                        Address = c.String(),
                        Email = c.String(),
                        Phone = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CompanyCustomers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        CompanyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Documents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CompanyCustomerId = c.Int(nullable: false),
                        Path = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Emails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ContactId = c.Int(nullable: false),
                        Text = c.String(),
                        Header = c.String(),
                        Time = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Exchanges",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CompanyCustomerId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        ContactId = c.Int(nullable: false),
                        NextContact = c.DateTime(nullable: false),
                        LastContact = c.DateTime(nullable: false),
                        Frequency = c.Int(nullable: false),
                        Priority = c.Int(nullable: false),
                        NextTryAttempt = c.DateTime(nullable: false),
                        LastTryAttempt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ExchangeId = c.Int(nullable: false),
                        CompanyCustomerId = c.Int(nullable: false),
                        Text = c.String(),
                        Time = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CompanyId = c.Int(nullable: false),
                        Type = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
            DropTable("dbo.Messages");
            DropTable("dbo.Exchanges");
            DropTable("dbo.Emails");
            DropTable("dbo.Documents");
            DropTable("dbo.Customers");
            DropTable("dbo.CompanyCustomers");
            DropTable("dbo.Companies");
            DropTable("dbo.AddressInfoes");
        }
    }
}
