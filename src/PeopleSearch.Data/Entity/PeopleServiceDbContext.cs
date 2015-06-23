using System.Data.Entity;
using PeopleSearch.Data.Entity.Model;
using PeopleSearch.Data.Entity.ModelConfiguration;

namespace PeopleSearch.Data.Entity
{
    [DbConfigurationType(typeof(PeopleServiceConfiguration))]
    public class PeopleServiceDbContext : DbContext, IPeopleServiceContext
    {
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<Interest> Interests { get; set; }
        public virtual DbSet<Address> Addresses { get; set; }

        public PeopleServiceDbContext(string nameOrConnectionString) : base(nameOrConnectionString)
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
