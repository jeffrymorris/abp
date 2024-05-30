using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;

namespace Volo.Abp.EntityFrameworkCore.Couchbase.Volo.Abp.ConnectionStrings;

[Dependency(ReplaceServices = true)]
public class CouchbaseConnectionStringChecker : IConnectionStringChecker, ITransientDependency
{
    public Task<AbpConnectionStringCheckResult> CheckAsync(string connectionString)
    {
        throw new NotImplementedException();
    }
}