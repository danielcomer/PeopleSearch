using Microsoft.Framework.ConfigurationModel;
using PeopleSearch.Common.Configuration;

namespace PeopleSearch.Wpf.Client
{
    public class ConfigurationAdapter : IConfigurationProvider
    {
        private readonly IConfiguration _configuration;

        public ConfigurationAdapter(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string Get(string key)
        {
            return _configuration[key];
        }
    }
}
