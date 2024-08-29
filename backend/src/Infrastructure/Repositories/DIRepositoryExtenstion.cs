

using Domain.Interfaces.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Repositories.Repositories;

namespace Repositories;

public static class DIRepositoryExtenstion
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<ISchoolRepository, SchoolRepository>();
        return services;
    }
}
