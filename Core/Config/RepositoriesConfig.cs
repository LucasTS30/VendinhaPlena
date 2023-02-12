using Core.Repositories.Clientes;
using Core.Repositories.Dividas;

namespace Core.Config;

public static class RepositoriesConfig
{
    public static void RegisterRepositories(this IServiceCollection service)
    {
        service.AddScoped<IClienteRepository, ClienteRepository>();
        service.AddScoped<IDividaRepository, DividaRepository>();
    }
}