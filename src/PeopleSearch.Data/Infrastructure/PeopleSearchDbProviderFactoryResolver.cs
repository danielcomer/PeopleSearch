//using System.Data.Common;
//using System.Data.Entity.Core.EntityClient;
//using System.Data.Entity.Infrastructure;
//using System.Data.SqlServerCe;

namespace PeopleSearch.Data.Infrastructure
{
    public class Class1
    {
    }
    //    public class PeopleSearchDbProviderFactoryResolver : IDbProviderFactoryResolver
    //    {
    //        private readonly DbProviderFactory _sqlServerCeDbProviderFactory = new SqlCeProviderFactory();

    //        public DbProviderFactory ResolveProviderFactory(DbConnection connection)
    //        {
    //            var assembly = connection.GetType().Assembly;

    //            if (assembly.FullName.Contains("System.Data.SqlServerCe"))
    //            {
    //                return _sqlServerCeDbProviderFactory;
    //            }

    //            return assembly.FullName.Contains("EntityFramework") ? EntityProviderFactory.Instance : null;
    //        }
    //    }

    //    //todo:
    //    // see https://technet.microsoft.com/en-us/library/ms173298(v=sql.110).aspx
    //    // and http://erikej.blogspot.dk/2014/10/entity-framework-6-and-sql-server.html
    //    // and http://erikej.blogspot.dk/2013/10/sql-server-compact-4-desktop-app-with.html
    //    // and https://www.nuget.org/packages/EntityFramework.SqlServerCompact.PrivateDeployment/
    //    //
}
