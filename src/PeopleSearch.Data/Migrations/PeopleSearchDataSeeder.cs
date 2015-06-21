using PeopleSearch.Data.Entity;

namespace PeopleSearch.Data.Migrations
{
    public static class PeopleSearchDataSeeder
    {
        public static void Seed(PeopleSearchDbContext context)
        {
            var people = FakeDataFactory.CreatePeople();
            var addresses = FakeDataFactory.CreateAddresses();
            var interests = FakeDataFactory.CreateInterests();

            context.People.AddRange(people);

            FakeDataFactory.AssociateAddressesWithPeople(people, addresses);

            context.Addresses.AddRange(addresses);

            context.Interests.AddRange(interests);

            context.SaveChanges();
        }

        
    }
}
