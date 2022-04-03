using System.Reflection;
using PromoMash.Application;
using PromoMash.Application.Common.Mapping;
using PromoMash.Application.Declaration;
using PromoMash.Persistence;
using PromoMash.WebApi.Middleware;

namespace PromoMash.WebApi;

public class Startup
{
    private IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration) => Configuration = configuration;

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddAutoMapper(config =>
        {
            config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
            config.AddProfile(new AssemblyMappingProfile(typeof(IPromoMashDbContext).Assembly));
        });

        services.AddApplication();
        services.AddPersistence(Configuration);
        services.AddControllers();

        services.AddCors(options =>
        {
            options.AddPolicy("AllowAll", policy =>
            {
                policy.AllowAnyHeader();
                policy.AllowAnyMethod();
                policy.AllowAnyOrigin();
            });
        });
        
        services.AddSwaggerGen(config =>
        {
            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            config.IncludeXmlComments(xmlPath);
        });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        
        app.UseSwagger();
        app.UseSwaggerUI(config =>
        {
            config.RoutePrefix = string.Empty;
            config.SwaggerEndpoint("swagger/v1/swagger.json", "PromoMash API");
        });
        
        app.UseCustomExceptionHandler();
        app.UseRouting();
        //app.UseHttpsRedirection();
        app.UseCors("AllowAll");

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapGet("/", async context =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
            endpoints.MapControllers();
        });
    }
}