namespace CleverCSM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedUserFromCompany : DbMigration
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
