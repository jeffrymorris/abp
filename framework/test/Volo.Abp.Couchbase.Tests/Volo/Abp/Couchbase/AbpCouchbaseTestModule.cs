using System;
using Couchbase;
using Couchbase.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Volo.Abp.Autofac;
using Volo.Abp.Couchbase.Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Couchbase.Volo.Couchbase;
using Volo.Abp.Data;
using Volo.Abp.Modularity;
using Volo.Abp.TestApp;
using Volo.Abp.TestApp.Domain;
using Volo.TestApp;
using Serilog.Extensions.Logging.File;
namespace Volo.Abp.Couchbase;

[DependsOn(
    typeof(TestAppModule),
    typeof(AbpCouchbaseModule), typeof(AbpAutofacModule))]
public class AbpCouchbaseTestModule: AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        var loggerFactory = LoggerFactory.Create(builder =>
        {
            builder.AddFilter(level => level >= LogLevel.Debug);
            builder.AddFile("Logs/myapp-{Date}.txt", LogLevel.Debug);
        });

        var connStr = Guid.NewGuid().ToString();

        Configure<AbpDbConnectionOptions>(options =>
        {
            options.ConnectionStrings.Default = connStr;
        });
        
        context.Services.AddCouchbase(options =>
        {
            options.WithConnectionString("couchbase://localhost");
            options.WithCredentials("Administrator", "password");
            options.WithLogging(loggerFactory);
        });
        context.Services.AddCouchbaseBucket<INamedBucketProvider>("default");
        context.Services.AddCouchbaseContext<TestAppCouchbaseContext>(options =>
        {
            options.AddDefaultRepositories();
            options.AddRepository<City, CityRepository>();
        });
    }
}