using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Store.Db;

public static class DIStoreExtension
{
    public static IServiceCollection AddStore(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<LibraryDbContext>(options =>
        {
            options.UseNpgsql(configuration["Postgre_Connection_String"]);
        });
        return services;
    }
}
