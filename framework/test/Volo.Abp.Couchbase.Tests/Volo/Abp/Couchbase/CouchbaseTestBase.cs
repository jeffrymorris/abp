using Volo.Abp.Testing;

namespace Volo.Abp.Couchbase;

public abstract class CouchbaseTestBase: AbpIntegratedTest<AbpCouchbaseTestModule>
{
    protected override void SetAbpApplicationCreationOptions(AbpApplicationCreationOptions options)
    {
        options.UseAutofac();
    }
}