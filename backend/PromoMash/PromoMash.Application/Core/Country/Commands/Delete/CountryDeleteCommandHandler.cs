using MediatR;
using PromoMash.Application.Common.Exception;
using PromoMash.Application.Declaration;
using PromoMash.Domain.Core;

namespace PromoMash.Application.Core.Country.Commands.Delete;

public class CountryDeleteCommandHandler : IRequestHandler<CountryDeleteCommand>
{
    private readonly IPromoMashDbContext _dbContext;

    public CountryDeleteCommandHandler(IPromoMashDbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public async Task<Unit> Handle(CountryDeleteCommand request, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.Countries.FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
        {
            throw new PromoMashNotFoundException(nameof(CountryEntity), request.Id);
        }

        _dbContext.Countries.Remove(entity);

        await _dbContext.SaveChangesAsync(cancellationToken);
        
        return Unit.Value;
    }
}