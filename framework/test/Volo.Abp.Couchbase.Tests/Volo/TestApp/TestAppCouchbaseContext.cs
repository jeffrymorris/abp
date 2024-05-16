using System;
using System.Collections.Generic;
using Couchbase;
using Couchbase.Extensions.DependencyInjection;
using JetBrains.Annotations;
using Volo.Abp.Couchbase.Volo.Couchbase;
using Volo.Abp.TestApp.Domain;
using Volo.Abp.TestApp.Testing;

namespace Volo.TestApp;

public class TestAppCouchbaseContext : CouchbaseContext
{
    private static readonly Type[] EntityTypeList = {
        typeof(Person),
        typeof(EntityWithIntPk),
        typeof(Product),
        typeof(AppEntityWithNavigations)
    };

    public override IReadOnlyList<Type> GetEntityTypes()
    {
        return EntityTypeList;
    }
}