namespace PeopleSearch.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Address",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        City = c.String(nullable: false, maxLength: 50),
                        StreetLineOne = c.String(nullable: false, maxLength: 50),
                        StreetLineTwo = c.String(maxLength: 50),
                        StateOrProvince = c.String(nullable: false, maxLength: 75),
                        Country = c.String(maxLength: 100),
                        PostalCode = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Person",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 60),
                        LastName = c.String(nullable: false, maxLength: 60),
                        Gender = c.Int(),
                        HomeAddressId = c.Int(nullable: false),
                        PortraitPicture = c.Binary(maxLength: 4000),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Address", t => t.HomeAddressId)
                .Index(t => t.FirstName)
                .Index(t => t.LastName)
                .Index(t => t.HomeAddressId);
            
            CreateTable(
                "dbo.Interest",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Text, unique: true);
            
            CreateTable(
                "dbo.PersonInterest",
                c => new
                    {
                        Person_Id = c.Int(nullable: false),
                        Interest_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Person_Id, t.Interest_Id })
                .ForeignKey("dbo.Person", t => t.Person_Id, cascadeDelete: true)
                .ForeignKey("dbo.Interest", t => t.Interest_Id, cascadeDelete: true)
                .Index(t => t.Person_Id)
                .Index(t => t.Interest_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PersonInterest", "Interest_Id", "dbo.Interest");
            DropForeignKey("dbo.PersonInterest", "Person_Id", "dbo.Person");
            DropForeignKey("dbo.Person", "HomeAddressId", "dbo.Address");
            DropIndex("dbo.PersonInterest", new[] { "Interest_Id" });
            DropIndex("dbo.PersonInterest", new[] { "Person_Id" });
            DropIndex("dbo.Interest", new[] { "Text" });
            DropIndex("dbo.Person", new[] { "HomeAddressId" });
            DropIndex("dbo.Person", new[] { "LastName" });
            DropIndex("dbo.Person", new[] { "FirstName" });
            DropTable("dbo.PersonInterest");
            DropTable("dbo.Interest");
            DropTable("dbo.Person");
            DropTable("dbo.Address");
        }
    }
}
