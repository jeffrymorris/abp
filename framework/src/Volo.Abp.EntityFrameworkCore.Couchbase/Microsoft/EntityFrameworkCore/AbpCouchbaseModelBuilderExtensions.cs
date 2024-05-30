using Microsoft.EntityFrameworkCore;

namespace Volo.Abp.EntityFrameworkCore.Couchbase.Microsoft.EntityFrameworkCore;

public static class AbpCouchbaseModelBuilderExtensions
{
    public static void UseCouchbase(this ModelBuilder modelBuilder)
    {
        modelBuilder.SetDatabaseProvider(EfCoreDatabaseProvider.Couchbase);
    }
}