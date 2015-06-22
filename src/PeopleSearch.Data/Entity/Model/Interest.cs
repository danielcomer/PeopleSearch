using System.Collections.Generic;

namespace PeopleSearch.Data.Entity.Model
{
    public class Interest
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public ICollection<Person> People { get; set; }

        public Interest()
        {
            People = new HashSet<Person>();
        }
    }
}
