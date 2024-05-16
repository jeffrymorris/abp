using Couchbase;
using Volo.Abp.DependencyInjection;

namespace Volo.Abp.Couchbase.Volo.Domain.Repositories.Couchbase;

public interface ICouchbaseDatabase
{
    ICluster Cluster { get; }
}

public class CouchbaseDatabase(ICluster cluster) : ICouchbaseDatabase, ITransientDependency
{
    public ICluster Cluster { get; } = cluster;
}