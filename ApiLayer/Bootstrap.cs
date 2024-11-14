using ApiLayer.Services;
using DataLayer.Postgre;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.MongoService;
using ToDoApp.Controllers;

namespace ToDoApp;

public static class Bootstrap
{
    public static void AddServices(this IServiceCollection services)
    {
        // other services...

        services.AddScoped<UserService>();
        // other configurations...
    }

    public static void AddDb(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("PostGreSql"), b => b.MigrationsAssembly("DataLayer")));
        services.AddSingleton<MongoDbContext>();
    }

    public static void AddSwaggerSettings(this IServiceCollection services)
    {
        services.AddMvc();
        services.AddRouting(options => options.LowercaseUrls = true);

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        services.AddEndpointsApiExplorer();
    }
}
