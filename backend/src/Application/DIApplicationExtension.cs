using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class DIApplicationExtension
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        return services;
    }
}
