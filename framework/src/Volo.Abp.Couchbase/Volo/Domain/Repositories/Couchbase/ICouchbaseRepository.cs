using Couchbase;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;

namespace Volo.Abp.Couchbase.Volo.Domain.Repositories.Couchbase;

public interface ICouchbaseRepository<TEntity> : IRepository<TEntity>
    where TEntity : class, IEntity
{
    Task<ICluster> GetDatabaseAsync(CancellationToken cancellationToken);
}

public interface ICouchbaseRepository<TEntity, TKey> : ICouchbaseRepository<TEntity>, IRepository<TEntity, TKey>
    where TEntity : class, IEntity<TKey>
{
}