using Api.DTOs;
using Core.Models;

namespace Core.Repositories.Clientes;

public interface IClienteRepository : ICrudRepository<Cliente, int>
{
    ICollection<ClienteComIdadeDTO> FindByName(string name);
    int CalculaIdade(DateTime dataNascimento);
    ICollection<Divida> ListarDividasClienteById(int id);
    //bool ValidaCpf(string cpf);
    ICollection<ClienteComIdadeDTO> FindAllComIdade();
    ICollection<Cliente> FindAllComDividaEmAberto();
    double SomaDasDividasPorClienteById(int id);
}