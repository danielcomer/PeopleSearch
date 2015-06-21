using System.Data.Entity;

namespace PeopleSearch.Data.Entity
{
    public interface IPeopleSearchDbContext : IDbContext
    {
        DbSet<Person> People { get; set; }
        DbSet<Interest> Interests { get; set; }
        DbSet<Address> Addresses { get; set; }
    }
}
