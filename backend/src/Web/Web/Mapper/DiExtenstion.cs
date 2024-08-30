namespace Web.Mapper;

public static class DiExtenstion
{
    public static IServiceCollection AddAutomapper(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(DiExtenstion).Assembly);
        return services;
    }
}
