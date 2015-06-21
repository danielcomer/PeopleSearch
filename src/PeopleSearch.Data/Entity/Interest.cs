using System.Collections.Generic;

namespace PeopleSearch.Data.Entity
{
    public class Interest
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public ICollection<Person> People { get; set; }
    }

    //todo: add categories
    //see: http://www.buzzle.com/articles/list-of-hobbies-interests.html
    //see: http://www.stormthecastle.com/the-list-of-hobbies.htm
}
