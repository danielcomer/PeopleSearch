using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.SqlServerCompact;
using System.Data.SqlServerCe;
using PeopleSearch.Data.Migrations;

namespace PeopleSearch.Data.Entity
{
    public class PeopleServiceConfiguration : DbConfiguration
    {
        public PeopleServiceConfiguration()
        {
            SetDatabaseInitializer(new MigrateDatabaseToLatestVersion<PeopleServiceContext, PeopleSearchMigrationsConfiguration>());
            SetProviderServices(SqlCeProviderServices.ProviderInvariantName, SqlCeProviderServices.Instance);
            SetDefaultConnectionFactory(new SqlCeConnectionFactory(SqlCeProviderServices.ProviderInvariantName));
            SetExecutionStrategy(SqlCeProviderServices.ProviderInvariantName, () => new DefaultExecutionStrategy());
            SetProviderFactory(SqlCeProviderServices.ProviderInvariantName, new SqlCeProviderFactory());
            SetContextFactory(() => new PeopleServiceContext("Data Source=PeopleServiceData.sdf;Persist Security Info=False;"));
        }
    }
}
