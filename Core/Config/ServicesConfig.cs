using Api.Clientes.Services;
using Api.Dividas.Services;

namespace Core.Config;

public static class ServicesConfig
{
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<IClienteService, ClienteService>();
        services.AddScoped<IDividaService, DividaService>();
    }
}