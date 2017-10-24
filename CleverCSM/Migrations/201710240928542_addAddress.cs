namespace CleverCSM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addAddress : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO AddressInfoes (Address,Email,Phone) VALUES ('Lyngbyvej 2','boss@clevercode.dk',60905234)");
            Sql("INSERT INTO AddressInfoes (Address,Email,Phone) VALUES ('Anker Engelunds Vej 1','boss@dtu.dk',14785236)");
            Sql("INSERT INTO AddressInfoes (Address,Email,Phone) VALUES ('Big Street 1','boss@bigboss.com',36985214)");
            Sql("INSERT INTO AddressInfoes (Address,Email,Phone) VALUES ('Lyngbyvej 2','paulin@clevercode.dk',60905234)");
            Sql("INSERT INTO AddressInfoes (Address,Email,Phone) VALUES ('Lyngbyvej 2','champ@clevercode.dk',12345678)");
            Sql("INSERT INTO AddressInfoes (Address,Email,Phone) VALUES ('Anker Engelunds Vej 1','champ@dtu.dk',12547896)");
            Sql("INSERT INTO AddressInfoes (Address,Email,Phone) VALUES ('Big Street 1','MainMain@bigboss.dk',25874125)");
        }
        
        public override void Down()
        {
        }
    }
}
