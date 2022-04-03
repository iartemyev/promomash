using MediatR;
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
        var entity = new ProvinceEntity(request.Name);

        await _dbContext.Provinces.AddAsync(entity, cancellationToken);
        
        await _dbContext.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}