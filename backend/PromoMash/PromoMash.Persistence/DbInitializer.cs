using Microsoft.EntityFrameworkCore;

namespace PromoMash.Persistence;

public static class DbInitializer
{
    public static void Initialize(PromoMashDbContext context)
    {
        context.Database.Migrate();
    }
}