using DMS.Infrastrcuture.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DMS.Infrastrcuture.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DMSDb");
        services.AddDbContext<DMSDbContext>(options =>
        {
            options.UseSqlServer(connectionString);
            options.EnableSensitiveDataLogging(configuration.GetValue<bool>("EnableSensitiveDataLogging", false));
        });

        AddCustomServices(services);
    }

    private static void AddCustomServices(IServiceCollection services)
    {
    }
}
