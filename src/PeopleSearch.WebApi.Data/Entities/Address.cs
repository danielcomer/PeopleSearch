namespace PeopleSearch.WebApi.Data.Entities
{
    public class Address
    {
        public int Id { get; set; }
        public string StreetLineOne { get; set; }
        public string StreetLineTwo { get; set; }
        public string City { get; set; }
        public string StateOrProvince { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
    }
}
