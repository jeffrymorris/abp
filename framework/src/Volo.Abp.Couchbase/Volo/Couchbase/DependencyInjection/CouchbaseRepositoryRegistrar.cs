using Volo.Abp.Couchbase.Volo.Domain.Repositories.Couchbase;
using Volo.Abp.Domain.Repositories;

namespace Volo.Abp.Couchbase.Volo.Couchbase.DependencyInjection;

public class CouchbaseRepositoryRegistrar : RepositoryRegistrarBase<AbpCouchbaseContextRegistrationOptions>
{
    public CouchbaseRepositoryRegistrar(AbpCouchbaseContextRegistrationOptions options) : base(options)
    {
    }

    protected override IEnumerable<Type> GetEntityTypes(Type dbContextType)
    {
        var context = (CouchbaseContext)Activator.CreateInstance(dbContextType)!;
        return context.GetEntityTypes();
    }

    protected override Type GetRepositoryType(Type dbContextType, Type entityType)
    {
        return typeof(CouchbaseRepository<,>).MakeGenericType(dbContextType, entityType);
    }

    protected override Type GetRepositoryType(Type dbContextType, Type entityType, Type primaryKeyType)
    {
        return typeof(CouchbaseRepository<,,>).MakeGenericType(dbContextType, entityType, primaryKeyType);
    }
}