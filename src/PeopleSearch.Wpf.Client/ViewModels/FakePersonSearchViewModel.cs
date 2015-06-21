using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using PeopleSearch.Data.Entity;
using PeopleSearch.Wpf.Client.Mvvm;

namespace PeopleSearch.Wpf.Client.ViewModels
{
    public class FakePersonSearchViewModel : ViewModelBase, IPersonSearchViewModel
    {
        public string SearchString { get; set; }

        public IObservableTask<IList<Person>> People { get; }

        public ICommand SearchByNameCommand { get; }

        public FakePersonSearchViewModel()
        {
            SearchString = "Hello";
            People = new FakeObservableTask<IList<Person>>()
            {
                Result = CreateFakePeople(),
                IsSuccessfullyCompleted = true
            };
            //SearchCommand = null;
        }

        private static IList<Person> CreateFakePeople()
        {
            return new List<Person>();
            //var a1 = new Address
            //{
            //    StreetLineOne = "1728 Candlelight Drive",
            //    City = "Houston",
            //    StateOrProvince = "TX",
            //    PostalCode = "77032"
            //};

            //var a2 = new Address
            //{
            //    StreetLineOne = "3439 Viking Drive",
            //    City = "Byesville",
            //    StateOrProvince = "OH",
            //    PostalCode = "43723"
            //};
            //var a3 = new Address
            //{
            //    StreetLineOne = "4594 Berkley Street",
            //    City = "Philadelphia",
            //    StateOrProvince = "PA",
            //    PostalCode = "19103"
            //};
            //var a4 = new Address
            //{
            //    StreetLineOne = "3202 Briercliff Road",
            //    City = "Hicksville",
            //    StateOrProvince = "NY",
            //    PostalCode = "11612"
            //};
            //var a5 = new Address
            //{
            //    StreetLineOne = "2016 Overlook Drive",
            //    City = "Indianapolis",
            //    StateOrProvince = "IN",
            //    PostalCode = "46225"
            //};
            //var a6 = new Address
            //{
            //    StreetLineOne = "3021 Stadium Drive",
            //    City = "Brockton",
            //    StateOrProvince = "MA",
            //    PostalCode = "02401"
            //};
            //var a7 = new Address
            //{
            //    StreetLineOne = "3403 Benedum Drive",
            //    City = "New Paltz",
            //    StateOrProvince = "NY",
            //    PostalCode = "12561"
            //};
            //var a8 = new Address
            //{
            //    StreetLineOne = "161 Clarence Court",
            //    City = "Long Beach",
            //    StateOrProvince = "NC",
            //    PostalCode = "28461"
            //};

            //var people = new List<Person>();

            //people.Add(new Person { Id = 1, FirstName = "Susan", LastName = "Nicholson", Gender = Gender.Female, HomeAddress = a1 });
            //people.Add(new Person { Id = 2, FirstName = "Albert", LastName = "Porter", Gender = Gender.Male, HomeAddress = a2 });
            //people.Add(new Person { Id = 3, FirstName = "Helen", LastName = "Short", Gender = Gender.Female, HomeAddress = a3 });
            //people.Add(new Person { Id = 4, FirstName = "Wendell", LastName = "Ford", Gender = Gender.Male, HomeAddress = a4 });
            //people.Add(new Person { Id = 5, FirstName = "Billy", LastName = "Lane", Gender = Gender.Male, HomeAddress = a5 });
            //people.Add(new Person { Id = 6, FirstName = "Roberto", LastName = "Peloquin", Gender = Gender.Male, HomeAddress = a6 });
            //people.Add(new Person { Id = 7, FirstName = "Carrie", LastName = "Crawford", Gender = Gender.Female, HomeAddress = a7 });
            //people.Add(new Person { Id = 8, FirstName = "Linwood", LastName = "McCarter", Gender = Gender.Female, HomeAddress = a8 });

            ////people.First().Interests = new List<string> {"Camping", "Hiking", "Fishing", "Acting", "Astrology", "Baseball", "Basketball", "BoardGames", "Bridge Building", "Casino Gambling" }

            //return people;
        }
    }
}
