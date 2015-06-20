using System.Data.Entity;
using PeopleSearch.Data.Entity;

namespace PeopleSearch.Data.Contexts
{
    public class PeopleServiceContext : DbContext
    {
        public DbSet<Person> People { get; set; }
        public DbSet<Interest> Interests { get; set; }
        public DbSet<Address> Addresses { get; set; }
        
        public PeopleServiceContext()
        {
            //todo: determine if this is good
            Configuration.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
                .HasMany(p => p.Interests)
                .WithMany(i => i.People)
                .Map(cs =>
                {
                    cs.MapLeftKey(nameof(Person) + "Id");
                    cs.MapRightKey(nameof(Interest) + "Id");
                    cs.ToTable(nameof(Person) + nameof(Interest) + "s");
                });

            modelBuilder.Entity<Person>()
                .HasRequired(p => p.HomeAddress)
                .WithMany(s => s.People)
                .Map(ca =>
                {
                    ca.MapKey(nameof(Person.HomeAddress) + "Id");
                });
        }
    }
}
