using PeopleSearch.Core.Infrastructure;
using PeopleSearch.Data.Entity.Model;

namespace PeopleSearch.Wpf.Client.ViewModels.Events
{
    public class PersonSelected : IEvent
    {
        public Person Person { get; }

        public PersonSelected(Person person)
        {
            Person = person;
        }
    }
}
