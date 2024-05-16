using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Volo.Abp.Couchbase.Volo.Couchbase;
using Volo.Abp.Couchbase.Volo.Couchbase.DependencyInjection;

namespace Volo.Abp.Couchbase.Microsoft.Extensions.DependencyInjection;

public static class AbpCouchbaseServiceCollectionExtensions
{
    public static IServiceCollection AddCouchbaseContext<TCouchbaseContext>(this IServiceCollection services,
        Action<IAbpCouchbaseContextRegistrationOptionsBuilder>? optionsBuilder = null)
        where TCouchbaseContext : CouchbaseContext
    {
        var options = new AbpCouchbaseContextRegistrationOptions(typeof(TCouchbaseContext), services);
        optionsBuilder?.Invoke(options);

        if (options.DefaultRepositoryDbContextType != typeof(TCouchbaseContext))
        {
            services.TryAddSingleton(options.DefaultRepositoryDbContextType, sp => sp.GetRequiredService<TCouchbaseContext>());
        }
        
        services.TryAddSingleton<CouchbaseContextOptions>();

        foreach (var entry in options.ReplacedDbContextTypes)
        {
            var originalDbContextType = entry.Key.Type;
            var targetDbContextType = entry.Value ?? typeof(TCouchbaseContext);

            services.Replace(
                ServiceDescriptor.Singleton(
                    originalDbContextType,
                    sp => sp.GetRequiredService(targetDbContextType)
                )
            );
        }

        new CouchbaseRepositoryRegistrar(options).AddRepositories();

        return services;
    }
}