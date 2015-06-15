using System.Collections.Generic;
using Microsoft.Data.Entity.Relational.Migrations;
using Microsoft.Data.Entity.Relational.Migrations.Builders;
using Microsoft.Data.Entity.Relational.Migrations.Operations;

namespace PeopleSearch.WebApi.Data.Migrations
{
    public partial class initial : Migration
    {
        public override void Up(MigrationBuilder migration)
        {
            migration.CreateSequence(
                name: "DefaultSequence",
                type: "bigint",
                startWith: 1L,
                incrementBy: 10);
            migration.CreateTable(
                name: "Address",
                columns: table => new
                {
                    City = table.Column(type: "nvarchar(max)", nullable: false),
                    Country = table.Column(type: "nvarchar(max)", nullable: true),
                    Id = table.Column(type: "int", nullable: false),
                    PostalCode = table.Column(type: "nvarchar(max)", nullable: true),
                    StateOrProvince = table.Column(type: "nvarchar(max)", nullable: true),
                    StreetLineOne = table.Column(type: "nvarchar(max)", nullable: false),
                    StreetLineTwo = table.Column(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                });
            migration.CreateTable(
                name: "Person",
                columns: table => new
                {
                    FirstName = table.Column(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column(type: "int", nullable: true),
                    HomeAddressId = table.Column(type: "int", nullable: true),
                    Id = table.Column(type: "int", nullable: false),
                    LastName = table.Column(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Person_Address_HomeAddressId",
                        columns: x => x.HomeAddressId,
                        referencedTable: "Address",
                        referencedColumn: "Id");
                });
        }
        
        public override void Down(MigrationBuilder migration)
        {
            migration.DropSequence("DefaultSequence");
            migration.DropTable("Address");
            migration.DropTable("Person");
        }
    }
}
