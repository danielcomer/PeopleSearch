using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using PeopleSearch.Data.Entity.Model;
using PeopleSearch.Data.Entity.ModelConfiguration;

namespace PeopleSearch.Data.Entity
{
    [DbConfigurationType(typeof(PeopleServiceConfiguration))]
    public class PeopleServiceContext : DbContext, IPeopleServiceContext
    {
        public DbSet<Person> People { get; set; }
        public DbSet<Interest> Interests { get; set; }
        public DbSet<Address> Addresses { get; set; }

        public PeopleServiceContext(string nameOrConnectionString) : base(nameOrConnectionString)
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
