using System.Collections.Generic;

namespace PeopleSearch.WebApi.Data.Entities
{
    public class Person
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Gender? Gender { get; set; }

        public Address HomeAddress { get; set; }

        public ICollection<string> Interests { get; set; }

        public Person()
        {
            HomeAddress = new Address();
            Interests = new List<string>();
        }
    }
}
