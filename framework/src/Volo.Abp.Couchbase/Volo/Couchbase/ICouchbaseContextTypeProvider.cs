namespace Volo.Abp.Couchbase.Volo.Couchbase;

public interface ICouchbaseContextTypeProvider
{
    Type GetDbContextType(Type dbContextType);
}