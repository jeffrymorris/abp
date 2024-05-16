using Volo.Abp.Couchbase.Volo.Couchbase;
using Volo.Abp.Uow;

namespace Volo.Abp.Couchbase.Volo.Uow;

public class CouchbaseDatabaseApi(ICouchbaseContext dbContext) : IDatabaseApi
{
    public ICouchbaseContext DbContext { get; } = dbContext;
}