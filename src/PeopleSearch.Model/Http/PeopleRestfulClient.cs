using PeopleSearch.Common.Configuration;
using PeopleSearch.Common.Http;
using PeopleSearch.Entities;

namespace PeopleSearch.Model.Http
{
    public class PeopleRestfulClient : SimpleJsonRestfulClient<Person>
    {
        public PeopleRestfulClient(IHttpClient client, IConfigurationProvider config) : base(client, config.Get("RestServices:PeopleBaseUrl"))
        {
        }
    }
}
