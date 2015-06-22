namespace PeopleSearch.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
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
                "dbo.People",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 60),
                        LastName = c.String(nullable: false, maxLength: 60),
                        Gender = c.Int(nullable: false),
                        HomeAddressId = c.Int(nullable: false),
                        PortraitPicture = c.Binary(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.HomeAddressId)
                .Index(t => t.FirstName)
                .Index(t => t.LastName)
                .Index(t => t.HomeAddressId);
            
            CreateTable(
                "dbo.Interests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Text, unique: true);
            
            CreateTable(
                "dbo.PersonInterests",
                c => new
                    {
                        Person_Id = c.Int(nullable: false),
                        Interest_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Person_Id, t.Interest_Id })
                .ForeignKey("dbo.People", t => t.Person_Id, cascadeDelete: true)
                .ForeignKey("dbo.Interests", t => t.Interest_Id, cascadeDelete: true)
                .Index(t => t.Person_Id)
                .Index(t => t.Interest_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PersonInterests", "Interest_Id", "dbo.Interests");
            DropForeignKey("dbo.PersonInterests", "Person_Id", "dbo.People");
            DropForeignKey("dbo.People", "HomeAddressId", "dbo.Addresses");
            DropIndex("dbo.PersonInterests", new[] { "Interest_Id" });
            DropIndex("dbo.PersonInterests", new[] { "Person_Id" });
            DropIndex("dbo.Interests", new[] { "Text" });
            DropIndex("dbo.People", new[] { "HomeAddressId" });
            DropIndex("dbo.People", new[] { "LastName" });
            DropIndex("dbo.People", new[] { "FirstName" });
            DropTable("dbo.PersonInterests");
            DropTable("dbo.Interests");
            DropTable("dbo.People");
            DropTable("dbo.Addresses");
        }
    }
}
