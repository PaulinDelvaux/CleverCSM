namespace CleverCSM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mailChange : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE AddressInfoes SET Email = 'MainMan@bigboss.dk' WHERE Id = 7; ");
        }
        
        public override void Down()
        {
        }
    }
}
