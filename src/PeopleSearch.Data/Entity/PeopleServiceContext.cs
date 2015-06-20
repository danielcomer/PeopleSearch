using System.Data.Entity;
using PeopleSearch.Core.Extensions;

namespace PeopleSearch.Data.Entity
{
    public class PeopleServiceContext : DbContext
    {
        public DbSet<Person> People { get; set; }
        public DbSet<Interest> Interests { get; set; }
        public DbSet<Address> Addresses { get; set; }
        
        public PeopleServiceContext()
        {
            Configuration.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
                .HasMany(p => p.Interests)
                .WithMany(i => i.People)
                .Map(cs =>
                {
                    cs.MapLeftKey(nameof(Person) + nameof(Person.Id));
                    cs.MapRightKey(nameof(Interest) + nameof(Interest.Id));
                    cs.ToTable(nameof(Person) + nameof(Interest).Pluralize());
                });

            modelBuilder.Entity<Person>()
                .HasRequired(p => p.HomeAddress)
                .WithMany(s => s.People)
                .Map(ca =>
                {
                    ca.MapKey(nameof(Person.HomeAddress) + nameof(Address.Id));
                });
        }
    }
}
