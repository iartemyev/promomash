using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using PromoMash.Application.Core.Country.Query.Read;
using PromoMash.Persistence;
using PromoMash.UnitTest.Common;
using Shouldly;
using Xunit;

namespace PromoMash.UnitTest.Core.Country.Query;

[Collection("QueryCollection")]
public class CountryReadQueryHandlerTests
{
    private readonly PromoMashDbContext _context;
    private readonly IMapper _mapper;

    public CountryReadQueryHandlerTests(QueryTestFixture fixture)
    {
        if (fixture == null) throw new ArgumentNullException(nameof(fixture));
        
        _context = fixture.Context;
        _mapper = fixture.Mapper;
    }

    [Fact]
    public async Task CountryReadQueryHandler_Success()
    {
        // Arrange
        var handler = new CountryReadQueryHandler(_context, _mapper);

        // Act
        var result = await handler.Handle(new CountryReadQuery ("909F7C29-891B-4BE1-8504-21F84F262084"), CancellationToken.None);

        // Assert
        result.ShouldBeOfType<CountryVm>();
        result.Name.ShouldBe("Country2");
    }
}