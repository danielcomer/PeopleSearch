using Microsoft.Data.Entity;
using PeopleSearch.WebApi.Data.Entities;

namespace PeopleSearch.WebApi.Data
{
    public interface IDirectoryDbContext
    {
        DbSet<Person> People { get; }
        DbSet<Address> Addresses { get; }
        int SaveChanges();
    }
}
