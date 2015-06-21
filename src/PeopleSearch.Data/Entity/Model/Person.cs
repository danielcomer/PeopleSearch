using System.Collections.Generic;

namespace PeopleSearch.Data.Entity.Model
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender? Gender { get; set; }
        public int HomeAddressId { get; set; }
        public Address HomeAddress { get; set; }
        public byte[] PortraitPicture { get; set; }
        public ICollection<Interest> Interests { get; set; }

        public Person()
        {
            Interests = new HashSet<Interest>();
        }
    }
}
