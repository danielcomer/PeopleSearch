using System.Collections.Generic;
using System.Windows.Input;
using PeopleSearch.Data.Entity.Model;
using PeopleSearch.Data.Migrations;
using PeopleSearch.Wpf.Client.Mvvm;

namespace PeopleSearch.Wpf.Client.ViewModels
{
    public class DesignTimePersonSearchViewModel : ViewModelBase, IPersonSearchViewModel
    {
        public Person SelectedPerson => null;

        public IObservableTask<IList<Person>> People => new FakeObservableTask<IList<Person>>
        {
            Result = CreateFakePeople(),
            IsSuccessfullyCompleted = true
        };

        public ICommand SearchByName => null;

        private static IList<Person> CreateFakePeople()
        {
            var people = FakeDataFactory.CreatePeople();
            var addresses = FakeDataFactory.CreateAddresses();
            var interests = FakeDataFactory.CreateInterests();

            FakeDataFactory.AssociateAddressesWithPeople(people, addresses);
            FakeDataFactory.AssociatePeopleWithInterests(people, interests);

            return people;
        }
    }
}
