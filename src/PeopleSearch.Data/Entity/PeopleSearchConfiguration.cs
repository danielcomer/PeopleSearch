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
            SetProviderFactoryResolver(new PeopleSearchDbProviderFactoryResolver());
        }
    }

    




}
