using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PromoMash.Application.Declaration;

namespace PromoMash.Application.Core.Province.Queries.List;

public class ProvinceListQueryHandler : IRequestHandler<ProvinceListQuery, ProvinceListVm>
{
    private readonly IPromoMashDbContext _dbContext;
    private readonly IMapper _mapper;

    public ProvinceListQueryHandler(IPromoMashDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<ProvinceListVm> Handle(ProvinceListQuery request, CancellationToken cancellationToken)
    {
        var entitiesQuery = await _dbContext.Provinces
            .Where(e => e.Country != null && e.Country.Id.Equals(request.CountryId))
            .ProjectTo<ProvinceLookupDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return new ProvinceListVm { Provincies = entitiesQuery };
    }
}