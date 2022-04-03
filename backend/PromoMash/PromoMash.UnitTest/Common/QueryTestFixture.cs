using System;
using AutoMapper;
using PromoMash.Application.Common.Mapping;
using PromoMash.Application.Declaration;
using PromoMash.Persistence;
using Xunit;

namespace PromoMash.UnitTest.Common;

public class QueryTestFixture : IDisposable
{
    public PromoMashDbContext Context;
    
    public IMapper Mapper;

    public QueryTestFixture()
    {
        Context = PromoMashContextFactory.Create();
        
        var configurationProvider = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new AssemblyMappingProfile(typeof(IPromoMashDbContext).Assembly));
        });
        
        Mapper = configurationProvider.CreateMapper();
    }

    public void Dispose()
    {
        PromoMashContextFactory.Destroy(Context);
    }
}

[CollectionDefinition("QueryCollection")]
public class QueryCollection : ICollectionFixture<QueryTestFixture> { }