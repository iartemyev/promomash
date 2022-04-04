using PromoMash.Persistence;
using Serilog;
using Serilog.Events;

namespace PromoMash.WebApi;

public static class Program
{
    public static void Main(string[] args)
    {
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
            .WriteTo.File("PromoMash.WebApi.Log-.log", rollingInterval:
                RollingInterval.Day)
            .WriteTo.Console()
            .CreateLogger();
        
        var host = CreateHostBuilder(args).Build();

        using (var scope = host.Services.CreateScope())
        {
            var serviceProvider = scope.ServiceProvider;
            try
            {
                var context = serviceProvider.GetRequiredService<PromoMashDbContext>();
                
                DbInitializer.Initialize(context);
            }
            catch (Exception exception)
            {
                Log.Fatal(exception, "An error occurred while app initialization");
            }
        }

        host.Run();
    }

    private static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .UseSerilog()
            .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
}