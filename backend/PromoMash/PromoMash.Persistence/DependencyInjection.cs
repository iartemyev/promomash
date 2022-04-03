using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PromoMash.Application.Declaration;

namespace PromoMash.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration["DbConnection"];
        
        services.AddDbContext<PromoMashDbContext>(options =>
        {
            options.UseSqlite(connectionString);
        });
        
        services.AddScoped<IPromoMashDbContext>(provider => provider.GetService<PromoMashDbContext>()!);

        return services;
    }
}