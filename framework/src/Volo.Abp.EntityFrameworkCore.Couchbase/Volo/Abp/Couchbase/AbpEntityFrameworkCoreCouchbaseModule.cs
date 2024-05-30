using Volo.Abp.Modularity;

namespace Volo.Abp.EntityFrameworkCore.Couchbase.Volo.Abp.Couchbase;

[DependsOn(
    typeof(AbpEntityFrameworkCoreModule)
)]
public class AbpEntityFrameworkCoreCouchbaseModule: AbpModule
{
}