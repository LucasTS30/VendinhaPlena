using Core.Data.Contexts;

namespace Core.Config;

public static class DataBaseConfig
{
    public static void RegisterDataBase(this IServiceCollection services)
    {
        services.AddDbContext<VendinhaPlenaDbContext>();
    }
}