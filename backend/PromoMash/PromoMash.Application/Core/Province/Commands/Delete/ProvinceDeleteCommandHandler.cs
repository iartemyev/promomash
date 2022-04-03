using MediatR;
using PromoMash.Application.Common.Exception;
using PromoMash.Application.Declaration;
using PromoMash.Domain.Core;

namespace PromoMash.Application.Core.Province.Commands.Delete;

public class ProvinceDeleteCommandHandler : IRequestHandler<ProvinceDeleteCommand>
{
    private readonly IPromoMashDbContext _dbContext;

    public ProvinceDeleteCommandHandler(IPromoMashDbContext dbContext)
    {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public async Task<Unit> Handle(ProvinceDeleteCommand request, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.Provinces.FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
        {
            throw new PromoMashNotFoundException(nameof(ProvinceEntity), request.Id);
        }

        _dbContext.Provinces.Remove(entity);

        await _dbContext.SaveChangesAsync(cancellationToken);
        
        return Unit.Value;
    }
}