using ServiceLayer.MongoService;
using ToDoApp.Controllers;

namespace ToDoApp;

public static class Bootstrap
{
    public static void AddServices(this IServiceCollection services)
    {
        // other services...

        services.AddSingleton<MongoDbContext>();
        services.AddScoped<UserController>();
        // other configurations...
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
