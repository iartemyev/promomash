namespace PromoMash.Persistence;

public class DbInitializer
{
    public static void Initialize(PromoMashDbContext context)
    {
        context.Database.EnsureCreated();
    }
}