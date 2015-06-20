using System.Data.Entity.ModelConfiguration;
using PeopleSearch.Data.Entity;

namespace PeopleSearch.Data.Configuration
{
    public class AddressEntityConfiguration : EntityTypeConfiguration<Address>
    {
        public AddressEntityConfiguration()
        {
            Property(a => a.StreetLineOne)
                .IsRequired()
                .HasMaxLength(50);

            Property(a => a.StreetLineTwo)
                .HasMaxLength(50);

            Property(a => a.City)
                .IsRequired()
                .HasMaxLength(50);

            Property(a => a.StateOrProvince)
                .IsRequired()
                .HasMaxLength(75);

            Property(a => a.Country)
                .HasMaxLength(100);

            Property(a => a.PostalCode)
                .IsRequired()
                .HasMaxLength(20);
        }
    }
}
