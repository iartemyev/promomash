using MediatR;
using PromoMash.Application.Declaration;
using PromoMash.Domain.Core;

namespace PromoMash.Application.Core.Country.Command.Create;

public class CountryCreateCommandHandler : IRequestHandler<CountryCreateCommand, string>
{
    private readonly IPromoMashDbContext _dbContext;

    public CountryCreateCommandHandler(IPromoMashDbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public async Task<string> Handle(CountryCreateCommand request, CancellationToken cancellationToken)
    {
        var entity = new CountryEntity(request.Name);

        await _dbContext.Countries.AddAsync(entity, cancellationToken);
        
        await _dbContext.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}