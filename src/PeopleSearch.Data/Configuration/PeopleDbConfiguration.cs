using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.SqlServerCompact;
using System.Data.SqlServerCe;
using PeopleSearch.Data.Entity;

namespace PeopleSearch.Data.Configuration
{
    public class PeopleDbConfiguration : DbConfiguration
    {
        public PeopleDbConfiguration()
        {
            SetDatabaseInitializer(new CreateDatabaseIfNotExists<PeopleSearchDbContext>());
            SetProviderServices(SqlCeProviderServices.ProviderInvariantName, SqlCeProviderServices.Instance);
            SetDefaultConnectionFactory(new SqlCeConnectionFactory(SqlCeProviderServices.ProviderInvariantName));
            SetExecutionStrategy(SqlCeProviderServices.ProviderInvariantName, () => new DefaultExecutionStrategy());
            SetProviderFactory(SqlCeProviderServices.ProviderInvariantName, new SqlCeProviderFactory());
        }
    }
}
