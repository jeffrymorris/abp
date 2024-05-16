using Microsoft.Extensions.Options;
using Volo.Abp.MultiTenancy;

namespace Volo.Abp.Couchbase.Volo.Couchbase;

public class CouchbaseContextTypeProvider(IOptions<CouchbaseContextOptions> options, ICurrentTenant currentTenant)
    : ICouchbaseContextTypeProvider
{
    private readonly IOptions<CouchbaseContextOptions> _options = options;
    private readonly ICurrentTenant _currentTenant = currentTenant;

    public Type GetDbContextType(Type dbContextType)
    {
        throw new NotImplementedException();
    }
}