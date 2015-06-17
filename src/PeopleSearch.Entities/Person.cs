using System.Collections.Generic;

namespace PeopleSearch.Entities
{
    public class Person
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Gender? Gender { get; set; }

        public virtual Address HomeAddress { get; set; }

        public virtual ICollection<TextOption> Interests { get; set; }

        public Person()
        {
            HomeAddress = new Address();
            Interests = new List<TextOption>();
        }
    }
}
