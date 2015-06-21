using System.Data.Entity.ModelConfiguration;
using PeopleSearch.Data.Entity.Model;

namespace PeopleSearch.Data.Entity.ModelConfiguration
{
    public class AddressEntityConfiguration : EntityTypeConfiguration<Address>
    {
        public AddressEntityConfiguration()
        {
            Property(a => a.StreetLineOne)
                .IsRequired()
                .IsUnicode(true)
                .HasMaxLength(50);

            Property(a => a.StreetLineTwo)
                .IsUnicode(true)
                .HasMaxLength(50);

            Property(a => a.City)
                .IsUnicode(true)
                .IsRequired()
                .HasMaxLength(50);

            Property(a => a.StateOrProvince)
                .IsUnicode(true)
                .IsRequired()
                .HasMaxLength(75);

            Property(a => a.Country)
                .IsUnicode(true)
                .HasMaxLength(100);

            Property(a => a.PostalCode)
                .IsRequired()
                .HasMaxLength(20);
        }
    }
}
