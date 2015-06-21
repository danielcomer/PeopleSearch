using System.Data.Entity.ModelConfiguration;
using PeopleSearch.Data.Entity;

namespace PeopleSearch.Data.Configuration
{
    public class InterestEntityConfiguration : EntityTypeConfiguration<Interest>
    {
        public InterestEntityConfiguration()
        {
            Property(i => i.Text)
                .IsRequired()
                .IsUnicode(true)
                .HasMaxLength(50);
        }
    }
}
