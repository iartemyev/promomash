using MediatR;
using Microsoft.EntityFrameworkCore;
using PromoMash.Application.Common.Exceptions;
using PromoMash.Application.Declaration;
using PromoMash.Domain.Core;

namespace PromoMash.Application.Core.Country.Commands.Update;

public class CountryUpdateCommandHandler : IRequestHandler<CountryUpdateCommand>
{
    private readonly IPromoMashDbContext _dbContext;

    public CountryUpdateCommandHandler(IPromoMashDbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public async Task<Unit> Handle(CountryUpdateCommand request, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.Countries.FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken: cancellationToken);

        if (entity == null)
        {
            throw new PromoMashNotFoundException(nameof(CountryEntity), request.Id);
        }

        entity.SetName(request.Name);

        await _dbContext.SaveChangesAsync(cancellationToken);
        
        return Unit.Value;
    }
}