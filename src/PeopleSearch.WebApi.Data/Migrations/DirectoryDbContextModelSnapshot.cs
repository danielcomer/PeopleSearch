using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Metadata.Builders;
using Microsoft.Data.Entity.Relational.Migrations.Infrastructure;
using PeopleSearch.Entities;
using PeopleSearch.WebApi.Data;

namespace PeopleSearch.WebApi.Data.Migrations
{
    [ContextType(typeof(DirectoryDbContext))]
    partial class DirectoryDbContextModelSnapshot : ModelSnapshot
    {
        public override IModel Model
        {
            get
            {
                var builder = new BasicModelBuilder()
                    .Annotation("SqlServer:ValueGeneration", "Sequence");
                
                builder.Entity("PeopleSearch.Entities.Address", b =>
                    {
                        b.Property<string>("City")
                            .Annotation("MaxLength", 30)
                            .Annotation("OriginalValueIndex", 0);
                        b.Property<string>("Country")
                            .Annotation("OriginalValueIndex", 1);
                        b.Property<int>("Id")
                            .GenerateValueOnAdd()
                            .Annotation("OriginalValueIndex", 2)
                            .Annotation("SqlServer:ValueGeneration", "Default");
                        b.Property<string>("PostalCode")
                            .Annotation("OriginalValueIndex", 3);
                        b.Property<string>("StateOrProvince")
                            .Annotation("OriginalValueIndex", 4);
                        b.Property<string>("StreetLineOne")
                            .Annotation("MaxLength", 30)
                            .Annotation("OriginalValueIndex", 5);
                        b.Property<string>("StreetLineTwo")
                            .Annotation("OriginalValueIndex", 6);
                        b.Key("Id");
                    });
                
                builder.Entity("PeopleSearch.Entities.Person", b =>
                    {
                        b.Property<string>("FirstName")
                            .Annotation("MaxLength", 30)
                            .Annotation("OriginalValueIndex", 0);
                        b.Property<Gender?>("Gender")
                            .Annotation("OriginalValueIndex", 1);
                        b.Property<int?>("HomeAddressId")
                            .Annotation("OriginalValueIndex", 2)
                            .Annotation("ShadowIndex", 0);
                        b.Property<int>("Id")
                            .GenerateValueOnAdd()
                            .Annotation("OriginalValueIndex", 3)
                            .Annotation("SqlServer:ValueGeneration", "Default");
                        b.Property<string>("LastName")
                            .Annotation("MaxLength", 30)
                            .Annotation("OriginalValueIndex", 4);
                        b.Key("Id");
                    });
                
                builder.Entity("PeopleSearch.Entities.Person", b =>
                    {
                        b.ForeignKey("PeopleSearch.Entities.Address", "HomeAddressId");
                    });
                
                return builder.Model;
            }
        }
    }
}
