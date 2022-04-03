using Microsoft.EntityFrameworkCore;
using PromoMash.Application.Declaration;
using PromoMash.Domain.Core;
using PromoMash.Persistence.EntityTypeConfiguration;

namespace PromoMash.Persistence;

public class PromoMashDbContext : DbContext, IPromoMashDbContext
{
    public DbSet<Country> Countries { get; set; }
    
    public DbSet<Province> Provinces { get; set; }

    public PromoMashDbContext(DbContextOptions<PromoMashDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ProvinceConfiguration());
        modelBuilder.ApplyConfiguration(new CountryConfiguration());
        base.OnModelCreating(modelBuilder);
    }
}