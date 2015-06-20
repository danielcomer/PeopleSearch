using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.SqlServerCompact;
using System.Data.SqlServerCe;
using PeopleSearch.Data.Infrastructure;

namespace PeopleSearch.Data.Entity
{
    public class PeopleSearchConfiguration : DbConfiguration
    {
        public PeopleSearchConfiguration()
        {
            SetExecutionStrategy("System.Data.SqlServerCe.4.0", () => new DefaultExecutionStrategy());
            SetProviderFactory("System.Data.SqlServerCe.4.0", new SqlCeProviderFactory());
            SetProviderServices("System.Data.SqlServerCe.4.0", SqlCeProviderServices.Instance);


            //todo:
            // see https://technet.microsoft.com/en-us/library/ms173298(v=sql.110).aspx
            // and http://erikej.blogspot.dk/2014/10/entity-framework-6-and-sql-server.html
            // and http://erikej.blogspot.dk/2013/10/sql-server-compact-4-desktop-app-with.html
            // and https://www.nuget.org/packages/EntityFramework.SqlServerCompact.PrivateDeployment/
            //
            SetProviderFactoryResolver(new PeopleSearchDbProviderFactoryResolver());
        }
    }

    
}
