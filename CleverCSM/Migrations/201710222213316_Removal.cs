namespace CleverCSM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Removal : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Companies", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Companies", "UserId", c => c.Int(nullable: false));
        }
    }
}
