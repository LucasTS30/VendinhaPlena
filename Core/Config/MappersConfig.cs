using Api.Dividas.Mappers;

namespace Core.Config;

public static class MappersConfig
{
    public static void RegisterMappers(this IServiceCollection services)
    {
        services.AddScoped<IDividaMapper, DividaMapper>();
    }
}