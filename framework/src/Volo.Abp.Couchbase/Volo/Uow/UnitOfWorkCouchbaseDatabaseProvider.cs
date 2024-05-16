using Couchbase;
using Couchbase.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Couchbase.Volo.Couchbase;
using Volo.Abp.Couchbase.Volo.Domain.Repositories.Couchbase;
using Volo.Abp.Data;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Threading;
using Volo.Abp.Uow;

namespace Volo.Abp.Couchbase.Volo.Uow;

public class UnitOfWorkCouchbaseDatabaseProvider<TCouchbaseContext>(
    IUnitOfWorkManager unitOfWorkManager,
    IConnectionStringResolver connectionStringResolver,
    ICancellationTokenProvider cancellationTokenProvider,
    ICurrentTenant currentTenant,
    CouchbaseContextOptions options)
    : ICouchbaseContextProvider<TCouchbaseContext>
    where TCouchbaseContext : ICouchbaseContext
{
    protected readonly IUnitOfWorkManager UnitOfWorkManager = unitOfWorkManager;
    protected readonly IConnectionStringResolver ConnectionStringResolver = connectionStringResolver;
    protected readonly ICancellationTokenProvider CancellationTokenProvider = cancellationTokenProvider;
    protected readonly ICurrentTenant CurrentTenant = currentTenant;
    protected readonly CouchbaseContextOptions Options = options;
    
    public async Task<TCouchbaseContext> GetDbContextAsync()
    {
        var uow = UnitOfWorkManager.Current;
        if (uow == null)
        {
            throw new AbpException(
                $"A {nameof(ICouchbaseDatabase)} instance can only be created inside a unit of work!");
        }
        var connectionString = await ConnectionStringResolver.ResolveAsync<TCouchbaseContext>();
        var dbContextKey = $"{typeof(TCouchbaseContext).FullName}_{connectionString}";

        var databaseApi = uow.FindDatabaseApi(dbContextKey);
        if (databaseApi == null)
        {
            var dbContext = uow.ServiceProvider.GetRequiredService<TCouchbaseContext>();
            await dbContext.InitializeAsync().ConfigureAwait(false);
            databaseApi = new CouchbaseDatabaseApi(dbContext);
            uow.AddDatabaseApi(dbContextKey, databaseApi);
        }

        return (TCouchbaseContext)((CouchbaseDatabaseApi)databaseApi).DbContext;
    }

    public async Task<ICluster> GetClusterAsync()
    {
        return (await GetDbContextAsync()).Cluster;
    }
}