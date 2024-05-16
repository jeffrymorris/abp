using System.Linq.Expressions;
using Couchbase;
using Couchbase.KeyValue;
using Google.Api;
using Volo.Abp.Couchbase.Volo.Couchbase;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;

namespace Volo.Abp.Couchbase.Volo.Domain.Repositories.Couchbase;

public class CouchbaseRepository<TCouchbaseContext, TEntity> : RepositoryBase<TEntity>, ICouchbaseRepository<TEntity>
    where TCouchbaseContext : CouchbaseContext
    where TEntity : class, IEntity
{
    protected CouchbaseRepository(ICouchbaseContextProvider<TCouchbaseContext> dbContextProvider)
    {
        DbContextProvider = dbContextProvider;
    }

    private ICouchbaseContextProvider<TCouchbaseContext> DbContextProvider { get; }
    
    public async override Task<TEntity> InsertAsync(TEntity entity, bool autoSave = false,
        CancellationToken cancellationToken = default)
    {
        var dbContext = await DbContextProvider.GetDbContextAsync().ConfigureAwait(false);
        throw new NotImplementedException();
    }

    public override Task<TEntity> UpdateAsync(TEntity entity, bool autoSave = false,
        CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public override Task DeleteAsync(TEntity entity, bool autoSave = false,
        CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public override Task<List<TEntity>> GetListAsync(bool includeDetails = false,
        CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public override Task<long> GetCountAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public override Task<List<TEntity>> GetPagedListAsync(int skipCount, int maxResultCount, string sorting,
        bool includeDetails = false,
        CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public override Task<IQueryable<TEntity>> GetQueryableAsync()
    {
        throw new NotImplementedException();
    }

    public override Task<TEntity?> FindAsync(Expression<Func<TEntity, bool>> predicate, bool includeDetails = true,
        CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public override Task DeleteAsync(Expression<Func<TEntity, bool>> predicate, bool autoSave = false,
        CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public override Task DeleteDirectAsync(Expression<Func<TEntity, bool>> predicate,
        CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public override Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate,
        bool includeDetails = false, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    protected override IQueryable<TEntity> GetQueryable()
    {
        throw new NotImplementedException();
    }

    public Task<ICluster> GetDatabaseAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}

public class CouchbaseRepository<TCouchbaseContext, TEntity, TKey> : 
    CouchbaseRepository<TCouchbaseContext, TEntity>,
    ICouchbaseRepository<TEntity, TKey>
    where TCouchbaseContext : CouchbaseContext
    where TEntity : class, IEntity<TKey>
{
    
    public CouchbaseRepository(ICouchbaseContextProvider<TCouchbaseContext> dbContextProvider)
        : base(dbContextProvider)
    {
        DbContextProvider = dbContextProvider;
    }

    private ICouchbaseContextProvider<TCouchbaseContext> DbContextProvider { get; }
    
    public async override Task<TEntity> InsertAsync(TEntity entity, bool autoSave = false, CancellationToken cancellationToken = default)
    {
        var dbContext = await DbContextProvider.GetDbContextAsync().ConfigureAwait(false);
        await (await dbContext.CollectionAsync(scopeName:null, collectionName:typeof(TEntity).Name.ToLower())).UpsertAsync(entity.Id.ToString(), entity);
        return entity;
    }

    public override Task<TEntity> UpdateAsync(TEntity entity, bool autoSave = false, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public override Task DeleteAsync(TEntity entity, bool autoSave = false, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public override Task<List<TEntity>> GetListAsync(bool includeDetails = false, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public override Task<long> GetCountAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public override Task<List<TEntity>> GetPagedListAsync(int skipCount, int maxResultCount, string sorting, bool includeDetails = false,
        CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public override Task<IQueryable<TEntity>> GetQueryableAsync()
    {
        throw new NotImplementedException();
    }

    public override Task<TEntity?> FindAsync(Expression<Func<TEntity, bool>> predicate, bool includeDetails = true, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public override Task DeleteAsync(Expression<Func<TEntity, bool>> predicate, bool autoSave = false, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public override Task DeleteDirectAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public override Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> predicate, bool includeDetails = false, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    protected override IQueryable<TEntity> GetQueryable()
    {
        throw new NotImplementedException();
    }

    public Task<ICluster> GetDatabaseAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<TEntity> GetAsync(TKey id, bool includeDetails = true, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<TEntity?> FindAsync(TKey id, bool includeDetails = true, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(TKey id, bool autoSave = false, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task DeleteManyAsync(IEnumerable<TKey> ids, bool autoSave = false, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}