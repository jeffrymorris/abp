using System.Data.Common;
using Couchbase.EntityFrameworkCore;
using Couchbase.EntityFrameworkCore.Infrastructure;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.DependencyInjection;

namespace Volo.Abp.EntityFrameworkCore.Couchbase;

public static class AbpDbContextConfigurationContextCouchbaseExtensions
{
    public static DbContextOptionsBuilder UseCouchbase(
        [NotNull] this AbpDbContextConfigurationContext context,
        Action<ICouchbaseDbContextOptionsBuilder>? couchbaseOptionsAction = null)
    {
        if (context.ExistingConnection != null)
        {
            return context.DbContextOptions.UseCouchbase(context.ConnectionString, optionsBuilder =>
            {
               // optionsBuilder.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
               couchbaseOptionsAction?.Invoke(optionsBuilder);
            });
        }
        else
        {
            return context.DbContextOptions.UseCouchbase(context.ConnectionString, optionsBuilder =>
            {
                //optionsBuilder.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
                couchbaseOptionsAction?.Invoke(optionsBuilder);
            });
        }
    }
}
