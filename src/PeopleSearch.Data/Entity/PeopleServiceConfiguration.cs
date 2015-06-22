using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.SqlServer;
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
            SetProviderServices(SqlProviderServices.ProviderInvariantName, SqlProviderServices.Instance);
            SetDefaultConnectionFactory(new SqlConnectionFactory());
            SetExecutionStrategy(SqlProviderServices.ProviderInvariantName, () => new DefaultExecutionStrategy());
            //SetProviderFactory(SqlProviderServices.ProviderInvariantName, );
            //SetProviderFactory(SqlCeProviderServices.ProviderInvariantName, new SqlCeProviderFactory());
            //SetContextFactory(() => new PeopleServiceContext("Data Source=PeopleServiceData.sdf;Persist Security Info=False;"));
            SetContextFactory(() => new PeopleServiceContext("Server=localhost; Database=PeopleServiceDataBase; Trusted_Connection=True;"));
        }
    }
}
