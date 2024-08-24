using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace Store.Cache;

public static class DICacheExtension
{
    public static IServiceCollection AddCache(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddStackExchangeRedisCache(options =>
        {
            options.InstanceName = "";
            options.Configuration = configuration["Redis_Connection_String"];
        });
        return services;
    }
}
