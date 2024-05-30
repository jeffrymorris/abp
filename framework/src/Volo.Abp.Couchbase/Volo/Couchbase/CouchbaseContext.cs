using Couchbase;
using Couchbase.Extensions.DependencyInjection;

namespace Volo.Abp.Couchbase.Volo.Couchbase;

public class CouchbaseContext: ICouchbaseContext
{
    public CouchbaseContext()
    {
    }
    
    public async Task<ICouchbaseCollection> CollectionAsync(string? scopeName = null, string? collectionName = null)
    {
        return scopeName switch {
            null when collectionName == null => Bucket.DefaultCollection(),
            null => Bucket.DefaultScope().Collection(collectionName),
            _ => Bucket.Scope(scopeName).Collection(collectionName ?? throw new ArgumentNullException(nameof(collectionName)))
        };
    }

    public IBucket? Bucket { get; set; }
    
    public ICluster? Cluster { get; set; }
    
    public INamedBucketProvider BucketProvider { get; set; }

    public async Task InitializeAsync()
    {
        Bucket ??= await BucketProvider.GetBucketAsync().ConfigureAwait(false);
        Cluster ??= Bucket.Cluster;
    }

    private readonly static Type[] EmptyTypeList = Type.EmptyTypes;

    public virtual IReadOnlyList<Type> GetEntityTypes()
    {
        return EmptyTypeList;
    }
}