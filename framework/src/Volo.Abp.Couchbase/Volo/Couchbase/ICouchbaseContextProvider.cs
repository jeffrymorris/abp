using Couchbase;

namespace Volo.Abp.Couchbase.Volo.Couchbase;

public interface ICouchbaseContextProvider<TCouchbaseContext> 
    where TCouchbaseContext : ICouchbaseContext
{
    Task<TCouchbaseContext> GetDbContextAsync();

    Task<ICluster> GetClusterAsync();
}