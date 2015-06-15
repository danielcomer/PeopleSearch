using Microsoft.Data.Entity;
using PeopleSearch.WebApi.Data.Entities;

namespace PeopleSearch.WebApi.Data
{
    
    public class DirectoryDbContext : DbContext, IDirectoryDbContext
    {
        public DbSet<Person> People { get; set; }
        public DbSet<Address> Addresses { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
                .Property(p => p.FirstName)
                .MaxLength(30)
                .Required();

            modelBuilder.Entity<Person>()
                .Property(p => p.LastName)
                .MaxLength(30)
                .Required();

            modelBuilder.Entity<Address>()
                .Property(a => a.StreetLineOne)
                .MaxLength(30)
                .Required();

            modelBuilder.Entity<Address>()
                .Property(a => a.City)
                .MaxLength(30)
                .Required();

            base.OnModelCreating(modelBuilder);
        }
    }
}
