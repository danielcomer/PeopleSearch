using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.SqlServer;
using PeopleSearch.Data.Migrations;

namespace PeopleSearch.Data.Entity
{
    public class PeopleServiceConfiguration : DbConfiguration
    {
        public PeopleServiceConfiguration()
        {
            SetDatabaseInitializer(new MigrateDatabaseToLatestVersion<PeopleServiceDbContext, PeopleSearchMigrationsConfiguration>());
            SetProviderServices(SqlProviderServices.ProviderInvariantName, SqlProviderServices.Instance);
            SetDefaultConnectionFactory(new SqlConnectionFactory());
            SetExecutionStrategy(SqlProviderServices.ProviderInvariantName, () => new DefaultExecutionStrategy());
            SetContextFactory(() => new PeopleServiceDbContext("Server=localhost; Database=PeopleServiceDataBase; Trusted_Connection=True;"));
        }
    }
}
