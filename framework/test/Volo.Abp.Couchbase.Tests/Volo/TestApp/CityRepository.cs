using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Couchbase.KeyValue;
using JetBrains.Annotations;
using Volo.Abp.Couchbase.Volo.Couchbase;
using Volo.Abp.Couchbase.Volo.Domain.Repositories.Couchbase;
using Volo.Abp.TestApp.Domain;

namespace Volo.TestApp;

public class CityRepository : CouchbaseRepository<TestAppCouchbaseContext, City, Guid>, ICityRepository
{
    public CityRepository([NotNull] [ItemNotNull] ICouchbaseContextProvider<TestAppCouchbaseContext> dbContextProvider) 
        : base(dbContextProvider)
    {
    }
    
    public Task<City> FindByNameAsync(string name)
    {
        throw new NotImplementedException();
    }

    public Task<List<Person>> GetPeopleInTheCityAsync(string cityName)
    {
        throw new NotImplementedException();
    }
}