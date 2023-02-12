using Api.Clientes.Validators;
using Core.Models;
using FluentValidation;

namespace Core.Config;

public static class ValidatorsConfig
{
    public static void RegisterValidators(this IServiceCollection services)
    {
        services.AddScoped<IValidator<Cliente>, ClienteValidator>(); 
        services.AddScoped<IValidator<Divida>, DividaValidator>(); 
    }
}