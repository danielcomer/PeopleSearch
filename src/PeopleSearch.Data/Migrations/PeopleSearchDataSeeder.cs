using System.Linq;
using PeopleSearch.Data.Entity;

namespace PeopleSearch.Data.Migrations
{
    public static class PeopleSearchDataSeeder
    {
        public static void Seed(PeopleServiceDbContext dbContext)
        {
            if (dbContext.People.Count() != 0) return;

            var people = FakeDataFactory.CreatePeople();
            var addresses = FakeDataFactory.CreateAddresses();
            var interests = FakeDataFactory.CreateInterests();

            dbContext.People.AddRange(people);

            dbContext.Addresses.AddRange(addresses);

            dbContext.Interests.AddRange(interests);

            FakeDataFactory.AssociateAddressesWithPeople(people, addresses);

            FakeDataFactory.AssociatePeopleWithInterests(people, interests);

            dbContext.SaveChanges();
        }
    }
}
