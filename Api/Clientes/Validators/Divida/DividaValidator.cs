using Core.Data.Contexts;
using Core.Models;
using FluentValidation;

namespace Api.Clientes.Validators;

public class DividaValidator : AbstractValidator<Divida>
{
    public DividaValidator(VendinhaPlenaDbContext context)
    {
        RuleFor(d => d.Valor).GreaterThan(0);
    }
}