using Api.Clientes.Mappers;
using Api.Common.DTOs;
using Api.DTOs;
using Core.Exceptions;
using Core.Models;
using Core.Repositories;
using Core.Repositories.Clientes;
using FluentValidation;

namespace Api.Clientes.Services;

public class ClienteService : IClienteService
{
    private readonly IClienteRepository _clienteRepository;
    private readonly IValidator<Cliente> _clienteValidator;

    public ClienteService(IClienteRepository clienteRepository, IValidator<Cliente> clienteValidator)
    {
        _clienteRepository = clienteRepository;
        _clienteValidator = clienteValidator;
    }

    public Cliente Create(Cliente cliente)
    {
        _clienteValidator.ValidateAndThrow(cliente);
        return _clienteRepository.Create(cliente);
    }

    public void DeleteById(int id)
    {
        if (!_clienteRepository.ExistsById(id))
        {
            throw new ModelNotFoundException($"Cliente com id {id} não foi encontrado.");
        }
        _clienteRepository.DeleteById(id);
    }

    public ICollection<Cliente> FindAll()
    {
        return _clienteRepository.FindAll();
    }

    // public PagedResponse<Cliente> FindAllComPaginacao(int pageNumber, int pageSize)
    // {
    //     var paginationOption = new PaginationOptions(pageNumber, pageSize);
    //     var pagedResult = _clienteRepository.FindAllComPaginacao(paginationOption);
    //     return _clienteMapper.ToPagedResponse(pagedResult);
    // }

    public ICollection<Cliente> FindAllComDividaEmAberto()
    {
        return _clienteRepository.FindAllComDividaEmAberto();
    }

    public ICollection<ClienteComIdadeDTO> FindAllComIdade()
    {
        return _clienteRepository.FindAllComIdade();
    }

    public Cliente FindById(int id)
    {
        var cliente = _clienteRepository.FindById(id);
        if (cliente is null)
        {
            throw new ModelNotFoundException($"Cliente com id {id} não encontrado.");
        }
        return cliente;
    }

    public ICollection<ClienteComIdadeDTO> FindByName(string name)
    {
        return _clienteRepository.FindByName(name);
    }

    public ICollection<Divida> ListarDividasClienteById(int id)
    {
        return _clienteRepository.ListarDividasClienteById(id);
    }

    public double SomaDasDividasPorClienteById(int id)
    {
        return _clienteRepository.SomaDasDividasPorClienteById(id);
    }

    public Cliente UpdateById(int id, Cliente cliente)
    {
        _clienteValidator.ValidateAndThrow(cliente);
        if (!_clienteRepository.ExistsById(id))
        {
            throw new ModelNotFoundException($"Cliente com id {id} não foi encontrado.");
        }
        cliente.Id = id;
        return _clienteRepository.Update(cliente);
    }
}