using System.Configuration;
using PeopleSearch.Common.Configuration;

namespace PeopleSearch.Wpf.Client.Configuration
{
    public class ConfigurationProvider : IConfigurationProvider
    {
        public string Get(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
    }
}
