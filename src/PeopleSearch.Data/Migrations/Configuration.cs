using System.Collections.Generic;
using PeopleSearch.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace PeopleSearch.Data.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<PeopleServiceContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(PeopleServiceContext context)
        {
            var people = CreatePeople();
            var addresses = CreateAddresses();

            context.People.AddRange(people);
            context.People.AddOrUpdate(p => p.Id);

            for (var i = 0; i <= addresses.Count; i++)
            {
                addresses[i].People.Add(people[i]);
            }

            context.Addresses.AddRange(addresses);

            base.Seed(context);
        }

        private static List<Address> CreateAddresses()
        {
            return new List<Address>
            {
                new Address
                {
                    StreetLineOne = "1728 Candlelight Drive",
                    City = "Houston",
                    StateOrProvince = "TX",
                    PostalCode = "77032"
                },

                new Address
                {
                    StreetLineOne = "3439 Viking Drive",
                    City = "Byesville",
                    StateOrProvince = "OH",
                    PostalCode = "43723"
                },

                new Address
                {
                    StreetLineOne = "4594 Berkley Street",
                    City = "Philadelphia",
                    StateOrProvince = "PA",
                    PostalCode = "19103"
                },
                new Address
                {
                    StreetLineOne = "3202 Briercliff Road",
                    City = "Hicksville",
                    StateOrProvince = "NY",
                    PostalCode = "11612"
                },
                new Address
                {
                    StreetLineOne = "2016 Overlook Drive",
                    City = "Indianapolis",
                    StateOrProvince = "IN",
                    PostalCode = "46225"
                },
                new Address
                {
                    StreetLineOne = "3021 Stadium Drive",
                    City = "Brockton",
                    StateOrProvince = "MA",
                    PostalCode = "02401"
                },
                new Address
                {
                    StreetLineOne = "3403 Benedum Drive",
                    City = "New Paltz",
                    StateOrProvince = "NY",
                    PostalCode = "12561"
                },
                new Address
                {
                    StreetLineOne = "161 Clarence Court",
                    City = "Long Beach",
                    StateOrProvince = "NC",
                    PostalCode = "28461"
                }
            };
        }

        private static List<Person> CreatePeople()
        {
            return new List<Person>
            {
                new Person { FirstName = "Susan", LastName = "Nicholson", Gender = Gender.Female},
                new Person { FirstName = "Albert", LastName = "Porter", Gender = Gender.Male},
                new Person { FirstName = "Helen", LastName = "Short", Gender = Gender.Female},
                new Person { FirstName = "Wendell", LastName = "Ford", Gender = Gender.Male},
                new Person { FirstName = "Billy", LastName = "Lane", Gender = Gender.Male},
                new Person { FirstName = "Roberto", LastName = "Peloquin", Gender = Gender.Male},
                new Person { FirstName = "Carrie", LastName = "Crawford", Gender = Gender.Female},
                new Person { FirstName = "Linwood", LastName = "McCarter", Gender = Gender.Female}
            };
        }
    }
}
