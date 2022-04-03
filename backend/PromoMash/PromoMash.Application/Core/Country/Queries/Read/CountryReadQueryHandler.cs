using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PromoMash.Application.Common.Exceptions;
using PromoMash.Application.Declaration;
using PromoMash.Domain.Core;

namespace PromoMash.Application.Core.Country.Queries.Read;

public class CountryReadQueryHandler : IRequestHandler<CountryReadQuery, CountryVm>
{
    private readonly IPromoMashDbContext _dbContext;
    private readonly IMapper _mapper;

    public CountryReadQueryHandler(IPromoMashDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
    }

    public async Task<CountryVm> Handle(CountryReadQuery request, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.Countries.FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken: cancellationToken);

        if (entity == null)
        {
            throw new PromoMashNotFoundException(nameof(CountryEntity), request.Id);
        }

        return _mapper.Map<CountryVm>(entity);
    }
}