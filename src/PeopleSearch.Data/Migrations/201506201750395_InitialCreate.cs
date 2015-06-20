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
                        FirstName = c.String(nullable: false, maxLength: 30),
                        LastName = c.String(nullable: false, maxLength: 30),
                        Gender = c.Int(),
                        PortraitPicture = c.Binary(maxLength: 4000),
                        HomeAddressId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.HomeAddressId, cascadeDelete: true)
                .Index(t => t.HomeAddressId);
            
            CreateTable(
                "dbo.Interests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PersonInterests",
                c => new
                    {
                        PersonId = c.Int(nullable: false),
                        InterestId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PersonId, t.InterestId })
                .ForeignKey("dbo.People", t => t.PersonId, cascadeDelete: true)
                .ForeignKey("dbo.Interests", t => t.InterestId, cascadeDelete: true)
                .Index(t => t.PersonId)
                .Index(t => t.InterestId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PersonInterests", "InterestId", "dbo.Interests");
            DropForeignKey("dbo.PersonInterests", "PersonId", "dbo.People");
            DropForeignKey("dbo.People", "HomeAddressId", "dbo.Addresses");
            DropIndex("dbo.PersonInterests", new[] { "InterestId" });
            DropIndex("dbo.PersonInterests", new[] { "PersonId" });
            DropIndex("dbo.People", new[] { "HomeAddressId" });
            DropTable("dbo.PersonInterests");
            DropTable("dbo.Interests");
            DropTable("dbo.People");
            DropTable("dbo.Addresses");
        }
    }
}
