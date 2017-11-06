namespace CleverCSM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changes : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "CompanyId", "dbo.Companies");
            DropIndex("dbo.Users", new[] { "CompanyId" });
            RenameColumn(table: "dbo.Users", name: "CompanyId", newName: "Company_Id");
            AddColumn("dbo.Users", "CompanyName", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "Company_Id", c => c.Int());
            CreateIndex("dbo.Users", "Company_Id");
            AddForeignKey("dbo.Users", "Company_Id", "dbo.Companies", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "Company_Id", "dbo.Companies");
            DropIndex("dbo.Users", new[] { "Company_Id" });
            AlterColumn("dbo.Users", "Company_Id", c => c.Int(nullable: false));
            DropColumn("dbo.Users", "CompanyName");
            RenameColumn(table: "dbo.Users", name: "Company_Id", newName: "CompanyId");
            CreateIndex("dbo.Users", "CompanyId");
            AddForeignKey("dbo.Users", "CompanyId", "dbo.Companies", "Id", cascadeDelete: true);
        }
    }
}
