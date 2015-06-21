using System.Collections.Generic;
using System.Windows.Input;
using PeopleSearch.Data.Entity.Model;
using PeopleSearch.Data.Migrations;
using PeopleSearch.Wpf.Client.Mvvm;

namespace PeopleSearch.Wpf.Client.ViewModels
{
    public class DesignTimePersonSearchViewModel : ViewModelBase, IPersonSearchViewModel
    {
        public string SearchString { get; set; }

        public IObservableTask<IList<Person>> People { get; }

        public ICommand SearchByName { get; }

        public DesignTimePersonSearchViewModel()
        {
            SearchString = "Hello";
            People = new FakeObservableTask<IList<Person>>()
            {
                Result = CreateFakePeople(),
                IsSuccessfullyCompleted = true
            };
            SearchByName = null;
        }

        private static IList<Person> CreateFakePeople()
        {
            var people = FakeDataFactory.CreatePeople();
            var addresses = FakeDataFactory.CreateAddresses();
            var interests = FakeDataFactory.CreateInterests();

            FakeDataFactory.AssociateAddressesWithPeople(people, addresses);

            return people;
        }
    }
}
