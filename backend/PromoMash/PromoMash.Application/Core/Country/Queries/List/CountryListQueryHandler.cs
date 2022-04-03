using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PromoMash.Application.Declaration;

namespace PromoMash.Application.Core.Country.Queries.List;

public class CountryListQueryHandler : IRequestHandler<CountryListQuery, CountryListVm>
{
    private readonly IPromoMashDbContext _dbContext;
    private readonly IMapper _mapper;

    public CountryListQueryHandler(IPromoMashDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<CountryListVm> Handle(CountryListQuery request, CancellationToken cancellationToken)
    {
        var entitiesQuery = await _dbContext.Countries
            .Where(entity => request.Text == null || entity.Name.StartsWith(request.Text))
            .ProjectTo<CountryLookupDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return new CountryListVm { Countries = entitiesQuery };
    }
}