using Microsoft.Extensions.DependencyInjection.Extensions;
using Volo.Abp.Couchbase.Volo.Uow;
using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace Volo.Abp.Couchbase.Volo.Couchbase;

[DependsOn(typeof(AbpDddDomainModule))]
public class AbpCouchbaseModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.TryAddTransient(
            typeof(ICouchbaseContextProvider<>),
            typeof(UnitOfWorkCouchbaseDatabaseProvider<>)
        );
    }
}