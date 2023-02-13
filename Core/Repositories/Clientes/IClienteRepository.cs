using Api.DTOs;
using Core.Models;

namespace Core.Repositories.Clientes;

public interface IClienteRepository : ICrudRepository<Cliente, int>//, IPagedRepository<Cliente>
{
    ICollection<ClienteComIdadeDTO> FindByName(string name);
    int CalculaIdade(DateTime dataNascimento);
    ICollection<Divida> ListarDividasClienteById(int id);
    ICollection<ClienteComIdadeDTO> FindAllComIdade();
    ICollection<Cliente> FindAllComDividaEmAberto();
    double SomaDasDividasPorClienteById(int id);

}