using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using PromoMash.Application.Core.Country.Query.List;
using PromoMash.Persistence;
using PromoMash.UnitTest.Common;
using Shouldly;
using Xunit;

namespace PromoMash.UnitTest.Core.Country.Query;

[Collection("QueryCollection")]
public class CountryListQueryHandlerTests
{
    private readonly PromoMashDbContext _context;
    private readonly IMapper _mapper;

    public CountryListQueryHandlerTests(QueryTestFixture fixture)
    {
        if (fixture == null) throw new ArgumentNullException(nameof(fixture));
        
        _context = fixture.Context;
        _mapper = fixture.Mapper;
    }
    
    [Fact]
    public async Task CountryListQueryHandler_Success()
    {
        // Arrange
        var handler = new CountryListQueryHandler(_context, _mapper);

        // Act
        var result = await handler.Handle(new CountryListQuery(null), CancellationToken.None);

        // Assert
        result.ShouldBeOfType<CountryListVm>();
        result.Countries.Count.ShouldBe(4);
    }
}