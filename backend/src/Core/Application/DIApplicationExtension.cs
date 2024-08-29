using Application.Services;
using Domain.Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class DIApplicationExtension
{
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<ISchoolService, SchoolService>();
        return services;
    }
}
