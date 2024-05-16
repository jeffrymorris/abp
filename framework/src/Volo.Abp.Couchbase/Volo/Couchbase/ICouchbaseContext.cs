using Couchbase;
using Couchbase.Extensions.DependencyInjection;
using Couchbase.KeyValue;
using Volo.Abp.DependencyInjection;

namespace Volo.Abp.Couchbase.Volo.Couchbase;

public interface ICouchbaseContext : ISingletonDependency
{
    Task<ICouchbaseCollection> CollectionAsync(string? scopeName = null, string? collectionName = null);
    
    IBucket Bucket { get; protected set; }

    ICluster Cluster { get; protected set; }
    
    INamedBucketProvider BucketProvider { get; set; }

    Task InitializeAsync();
}