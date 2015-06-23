using System;
using System.Linq;
using PeopleSearch.Data.Entity;

namespace PeopleSearch.Data.Migrations
{
    public static class PeopleSearchDataSeeder
    {
        public static void Seed(PeopleServiceContext context)
        {
            if (context.People.Count() != 0) return;

            var people = FakeDataFactory.CreatePeople();
            var addresses = FakeDataFactory.CreateAddresses();
            var interests = FakeDataFactory.CreateInterests();

            context.People.AddRange(people);

            context.Addresses.AddRange(addresses);

            context.Interests.AddRange(interests);

            FakeDataFactory.AssociateAddressesWithPeople(people, addresses);

            FakeDataFactory.AssociatePeopleWithInterests(people, interests);

            context.SaveChanges();
        }
    }
}
