using Core.Exceptions;
using Core.Models;
using Core.Repositories.Dividas;
using FluentValidation;

namespace Api.Dividas.Services;

public class DividaService : IDividaService
{
    private readonly IDividaRepository _dividaRepository;
    private readonly IValidator<Divida> _dividaValidator;

    public DividaService(IDividaRepository dividaRepository, IValidator<Divida> dividaValidator)
    {
        _dividaRepository = dividaRepository;
        _dividaValidator = dividaValidator;
    }

    public Divida Create(Divida divida)
    {
        _dividaValidator.ValidateAndThrow(divida);
        var dividaEmAberto = _dividaRepository.ExistsDividaEmAbertoByClienteId(divida.ClienteId);
        if (dividaEmAberto)
        {
            throw new DividaEmAbertoException($"Uma nova dívida não pode ser criada, pois o cliente já possui dívida em aberto.");
        }
        return _dividaRepository.Create(divida);
    }

    public void DeleteById(int id)
    {
        if (!_dividaRepository.ExistsById(id))
        {
            throw new ModelNotFoundException($"Dívida com id {id} não foi encontrada.");
        }
        _dividaRepository.DeleteById(id);
    }

    public ICollection<Divida> FindAll()
    {
        return _dividaRepository.FindAll();
    }

    public Divida FindById(int id)
    {
        var divida = _dividaRepository.FindById(id);
        if (divida is null)
        {
            throw new ModelNotFoundException($"Dívida com id {id} não encontrada.");
        }
        return divida;
    }

    public void PagarDividaById(int id)
    {
        _dividaRepository.PagarDividaById(id);
    }

    public float SomaDasDividasEmAberto()
    {
        return _dividaRepository.SomaDasDividasEmAberto();
    }

    public float SomaDasDividasTotais()
    {
        return _dividaRepository.SomaDasDividasTotais();
    }

    public Divida UpdateById(int id, Divida divida)
    {
        _dividaValidator.ValidateAndThrow(divida);
        if (!_dividaRepository.ExistsById(id))
        {
            throw new ModelNotFoundException($"Dívida com esse id {id} não foi encontrada.");
        }
        divida.Id = id;
        return _dividaRepository.Update(divida);
    }
}
