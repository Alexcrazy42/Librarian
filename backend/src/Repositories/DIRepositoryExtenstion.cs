

using Microsoft.Extensions.DependencyInjection;

namespace Repositories;

public static class DIRepositoryExtenstion
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        return services;
    }
}
