using System.Collections.Generic;
using System.Linq;
using PeopleSearch.Entities;

namespace PeopleSearch.WebApi.Data
{
    public class DbContextDirectoryRepository : IDirectoryRepository
    {
        private readonly IDirectoryDbContext _db;

        public DbContextDirectoryRepository(IDirectoryDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Person> GetAllPeople()
        {
            return _db.People.AsEnumerable();
        }

        public Person GetPerson(int personId)
        {
            return _db.People.FirstOrDefault(p => p.Id == personId);
        }

        public Person AddPerson(Person person)
        {
            _db.People.Add(person);
            return _db.SaveChanges() > 0 ? person : null;
        }

        public bool DeletePerson(int personId)
        {
            var person = _db.People.FirstOrDefault(p => p.Id == personId);

            if (person == null) return false;

            _db.People.Remove(person);

            return _db.SaveChanges() > 0;
        }
    }
}
