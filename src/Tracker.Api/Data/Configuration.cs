using Microsoft.EntityFrameworkCore;

namespace Tracker.Api.Data;

public static class Configuration
{
    public static IServiceCollection AddData(this IServiceCollection services,
        ConfigurationManager configurationManager)
    {
        services.AddDbContext<AppDbContext>(options =>
        {
            var connectionString = configurationManager.GetConnectionString("Default");
            options.UseNpgsql(connectionString);
        });
        services.AddHostedService<DatabaseInitializer>();
        return services;
    }
}