using MediatR;
using Microsoft.EntityFrameworkCore;
using PromoMash.Application.Common.Exception;
using PromoMash.Application.Declaration;
using PromoMash.Domain.Core;

namespace PromoMash.Application.Core.Province.Command.Update;

public class ProvinceUpdateCommandHandler : IRequestHandler<ProvinceUpdateCommand>
{
    private readonly IPromoMashDbContext _dbContext;

    public ProvinceUpdateCommandHandler(IPromoMashDbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public async Task<Unit> Handle(ProvinceUpdateCommand request, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.Provinces.FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken: cancellationToken);

        if (entity == null)
        {
            throw new PromoMashNotFoundException(nameof(ProvinceEntity), request.Id);
        }

        entity.SetName(request.Name);

        await _dbContext.SaveChangesAsync(cancellationToken);
        
        return Unit.Value;
    }
}