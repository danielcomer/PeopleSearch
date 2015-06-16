using System.Collections.Generic;
using PeopleSearch.Entities;

namespace PeopleSearch.WebApi.Data
{
    public interface IDirectoryRepository
    {
        IEnumerable<Person> GetAllPeople();
        Person GetPerson(int personId);
        Person AddPerson(Person person);
        bool DeletePerson(int personId);
    }
}
