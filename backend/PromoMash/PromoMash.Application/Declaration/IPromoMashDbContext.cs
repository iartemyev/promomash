using Microsoft.EntityFrameworkCore;
using PromoMash.Domain.Core;

namespace PromoMash.Application.Declaration;

public interface IPromoMashDbContext
{
    DbSet<Country> Countries { get; set; }
    DbSet<Province> Provinces { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}