using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.DependencyInjection;

namespace Volo.Abp.Couchbase.Volo.Couchbase.DependencyInjection;

public class AbpCouchbaseContextRegistrationOptions : AbpCommonDbContextRegistrationOptions, IAbpCouchbaseContextRegistrationOptionsBuilder
{
    public AbpCouchbaseContextRegistrationOptions(Type originalDbContextType, IServiceCollection services) 
        : base(originalDbContextType, services)
    {
    }
}