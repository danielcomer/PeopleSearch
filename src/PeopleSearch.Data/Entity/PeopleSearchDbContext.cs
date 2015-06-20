using System.Data.Entity;
using PeopleSearch.Data.Configuration;

namespace PeopleSearch.Data.Entity
{
    [DbConfigurationType(typeof(PeopleDbConfiguration))]
    public class PeopleSearchDbContext : DbContext
    {
        public DbSet<Person> People { get; set; }
        public DbSet<Interest> Interests { get; set; }
        public DbSet<Address> Addresses { get; set; }
        
        public PeopleSearchDbContext()
        {
            Configuration.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new PersonEntityConfiguration());
            modelBuilder.Configurations.Add(new AddressEntityConfiguration());
            modelBuilder.Configurations.Add(new InterestEntityConfiguration());
        }
    }
}
