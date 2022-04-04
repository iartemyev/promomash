using MediatR;
using Microsoft.EntityFrameworkCore;
using PromoMash.Application.Common.Exception;
using PromoMash.Application.Declaration;
using PromoMash.Domain.Core;

namespace PromoMash.Application.Core.Province.Command.Create;

public class ProvinceCreateCommandHandler : IRequestHandler<ProvinceCreateCommand, string>
{
    private readonly IPromoMashDbContext _dbContext;

    public ProvinceCreateCommandHandler(IPromoMashDbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public async Task<string> Handle(ProvinceCreateCommand request, CancellationToken cancellationToken)
    {
        var country = await _dbContext.Countries.FirstOrDefaultAsync(e => e.Id == request.CountryId, cancellationToken: cancellationToken);

        if (country == null)
        {
            throw new PromoMashNotFoundException(nameof(CountryEntity), request.CountryId);
        }
        
        var entity = new ProvinceEntity(request.Name, country);

        await _dbContext.Provinces.AddAsync(entity, cancellationToken);
        
        await _dbContext.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}