using Volo.Abp.Couchbase.Volo.Domain.Repositories.Couchbase;

namespace Volo.Abp.Couchbase.Volo.Couchbase;

public interface ICouchbaseDatabaseProvider<TCouchbaseContext>
    where TCouchbaseContext : CouchbaseContext
{
    Task<TCouchbaseContext> GetDbContextAsync();
    
    Task< ICouchbaseDatabase> GetDatabaseAsync();
}