namespace PeopleSearch.Common.Configuration
{
    public interface IConfigurationProvider
    {
        string Get(string key);
    }
}
