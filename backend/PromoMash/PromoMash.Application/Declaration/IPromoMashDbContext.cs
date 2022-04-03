using Microsoft.EntityFrameworkCore;
using PromoMash.Domain.Core;

namespace PromoMash.Application.Declaration;

public interface IPromoMashDbContext
{
    DbSet<CountryEntity> Countries { get; set; }
    
    DbSet<ProvinceEntity> Provinces { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}