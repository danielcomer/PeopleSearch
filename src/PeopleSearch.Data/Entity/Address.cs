using System.Collections.Generic;

namespace PeopleSearch.Data.Entity
{
    public class Address
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string StreetLineOne { get; set; }
        public string StreetLineTwo { get; set; }
        public string StateOrProvince { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }

        public ICollection<Person> People { get; set; }
    }

    //todo: List of countries / states / postal codes
}
