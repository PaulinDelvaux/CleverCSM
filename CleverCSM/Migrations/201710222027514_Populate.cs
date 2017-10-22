namespace CleverCSM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Populate : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Companies (Name,UserId) VALUES ('CleverCode',1)");
            Sql("INSERT INTO Companies (Name,UserId) VALUES ('DTU',2)");

            Sql("INSERT INTO Users (Name,CompanyId,Type) VALUES ('Polle',1,1)");
            Sql("INSERT INTO Users (Name,CompanyId,Type) VALUES ('Paulin',1,1)");
            Sql("INSERT INTO Users (Name,CompanyId,Type) VALUES ('Champ 2',2,2)");

            Sql("INSERT INTO Customers (Name) VALUES ('Bigly Customer')");

            Sql("INSERT INTO Contacts (Name, CustomerId) VALUES ('Main Man',1)");

            Sql("INSERT INTO CompanyCustomers (CustomerId, CompanyId) VALUES (1,1)");

            Sql("INSERT INTO AddressInfoes (InfoType,InfoTypeId,Address,Email,Phone) VALUES (1,1,'Lyngbyvej 2','boss@clevercode.dk',60905234)");
            Sql("INSERT INTO AddressInfoes (InfoType,InfoTypeId,Address,Email,Phone) VALUES (1,2,'Anker Engelunds Vej 1','boss@dtu.dk',14785236)");
            Sql("INSERT INTO AddressInfoes (InfoType,InfoTypeId,Address,Email,Phone) VALUES (2,1,'Big Street 1','boss@bigboss.com',36985214)");
            Sql("INSERT INTO AddressInfoes (InfoType,InfoTypeId,Address,Email,Phone) VALUES (3,1,'Lyngbyvej 2','paulin@clevercode.dk',60905234)");
            Sql("INSERT INTO AddressInfoes (InfoType,InfoTypeId,Address,Email,Phone) VALUES (3,2,'Lyngbyvej 2','champ@clevercode.dk',12345678)");
            Sql("INSERT INTO AddressInfoes (InfoType,InfoTypeId,Address,Email,Phone) VALUES (3,3,'Anker Engelunds Vej 1','champ@dtu.dk',12547896)");
            Sql("INSERT INTO AddressInfoes (InfoType,InfoTypeId,Address,Email,Phone) VALUES (4,1,'Big Street 1','MainMain@bigboss.dk',25874125)");

            Sql("INSERT INTO Exchanges (CompanyCustomerId,UserId,ContactId,NextContact,LastContact,Frequency,Priority,NextTryAttempt,LastTryAttempt) VALUES (1,2,1,12/12/2017,22/10/2017,14,1,12/12/2017,12/12/2017)");

        }
        
        public override void Down()
        {
        }
    }
}
