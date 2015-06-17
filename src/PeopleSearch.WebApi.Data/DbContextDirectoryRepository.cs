using System;
using System.Collections.Generic;
using System.Linq;
using PeopleSearch.Entities;
using PeopleSearch.Common.Extensions;

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
            return _db.People
                .Include(p => p.HomeAddress)
                .AsEnumerable();
        }

        public IEnumerable<Person> FindByName(string name)
        {
            return _db.People
                .Include(p => p.HomeAddress)
                .Where(p => (p.FirstName + p.LastName).Contains(name, StringComparison.CurrentCultureIgnoreCase))
                .AsEnumerable();
        }

        public Person GetPerson(int personId)
        {
            return _db.People
                .Include(p => p.HomeAddress)
                .FirstOrDefault(p => p.Id == personId);
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
