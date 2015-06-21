using System.Data.Entity;
using PeopleSearch.Data.Entity.Model;

namespace PeopleSearch.Data.Entity
{
    public interface IPeopleServiceContext : IDbContext
    {
        DbSet<Person> People { get; set; }
        DbSet<Interest> Interests { get; set; }
        DbSet<Address> Addresses { get; set; }
    }
}
