using Couchbase.EntityFrameworkCore.Infrastructure;
using JetBrains.Annotations;

namespace Volo.Abp.EntityFrameworkCore.Couchbase;

public static class AbpDbContextOptionsCouchbaseExtensions
{
    public static void UseCouchbase(
        [NotNull] this AbpDbContextOptions options,
        Action<ICouchbaseDbContextOptionsBuilder>? couchbaseOptionsAction = null)
    {
        options.Configure(context =>
        {
            context.UseCouchbase(couchbaseOptionsAction);
        });
    }

    public static void UseCouchbase<TDbContext>(
        [NotNull] this AbpDbContextOptions options,
        Action<ICouchbaseDbContextOptionsBuilder>? couchbaseOptionsAction = null)
        where TDbContext : AbpDbContext<TDbContext>
    {
        options.Configure<TDbContext>(context =>
        {
            context.UseCouchbase(couchbaseOptionsAction);
        });
    }
}
