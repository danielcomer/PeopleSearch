using System.Data.Common;
using System.Data.Entity.Core.EntityClient;
using System.Data.Entity.Infrastructure;
using System.Data.SqlServerCe;

namespace PeopleSearch.Data.Infrastructure
{
    internal class PeopleSearchDbProviderFactoryResolver : IDbProviderFactoryResolver
    {
        private readonly DbProviderFactory _sqlServerCeDbProviderFactory = new SqlCeProviderFactory();

        public DbProviderFactory ResolveProviderFactory(DbConnection connection)
        {
            var assembly = connection.GetType().Assembly;

            if (assembly.FullName.Contains("System.Data.SqlServerCe"))
            {
                return _sqlServerCeDbProviderFactory;
            }

            return assembly.FullName.Contains("EntityFramework") ? EntityProviderFactory.Instance : null;
        }
    }
}
