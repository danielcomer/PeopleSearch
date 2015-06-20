using System.Data.Entity.ModelConfiguration;
using PeopleSearch.Core.Extensions;
using PeopleSearch.Data.Entity;

namespace PeopleSearch.Data.Configuration
{
    public class PersonEntityConfiguration : EntityTypeConfiguration<Person>
    {
        public PersonEntityConfiguration()
        {
            HasMany(p => p.Interests)
                .WithMany(i => i.People)
                .Map(cs =>
                {
                    cs.MapLeftKey(nameof(Person) + nameof(Person.Id));
                    cs.MapRightKey(nameof(Interest) + nameof(Interest.Id));
                    cs.ToTable(nameof(Person) + nameof(Interest).Pluralize());
                });

            HasRequired(p => p.HomeAddress)
                .WithMany(s => s.People)
                .Map(ca =>
                {
                    ca.MapKey(nameof(Person.HomeAddress) + nameof(Address.Id));
                });

            Property(p => p.FirstName)
                .IsRequired()
                .HasMaxLength(30);

            Property(p => p.LastName)
                .IsRequired()
                .HasMaxLength(30);
        }
    }
}
