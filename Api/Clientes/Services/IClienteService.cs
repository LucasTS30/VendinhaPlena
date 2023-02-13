using Api.Common.DTOs;
using Api.DTOs;
using Core.Models;

namespace Api.Clientes.Services;

public interface IClienteService
{
    ICollection<Cliente> FindAll();
    ICollection<ClienteComIdadeDTO> FindAllComIdade();
    Cliente FindById(int id);
    ICollection<Divida> ListarDividasClienteById(int id);
    Cliente Create(Cliente cliente);
    Cliente UpdateById(int id, Cliente cliente);
    void DeleteById(int id);
    ICollection<ClienteComIdadeDTO> FindByName(string name);
    ICollection<Cliente> FindAllComDividaEmAberto();
    double SomaDasDividasPorClienteById(int id);
    //PagedResponse<Cliente> FindAllComPaginacao(int pageNumber, int pageSize);
}