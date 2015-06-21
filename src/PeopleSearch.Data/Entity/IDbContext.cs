using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Threading;
using System.Threading.Tasks;

namespace PeopleSearch.Data.Entity
{
    public interface IDbContext : IDisposable
    {
        Task<int> SaveChangesAsync();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        IEnumerable<DbEntityValidationResult> GetValidationErrors();
        //bool ShouldValidateEntity(DbEntityEntry entityEntry);
        //DbEntityValidationResult ValidateEntity(DbEntityEntry entityEntry, IDictionary<object, object> items);
        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
        //not so sure
        DbChangeTracker ChangeTracker { get; }
        DbContextConfiguration Configuration { get; }
        Database Database { get; }
    }
}
