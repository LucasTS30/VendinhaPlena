using Api.Dividas.DTOs;
using Core.Models;

namespace Core.Repositories.Dividas;

public interface IDividaRepository : ICrudRepository<Divida, int>
{
    bool ExistsDividaEmAbertoByClienteId(int id);
    void PagarDividaById(int id);
    float SomaDasDividasEmAberto();
    float SomaDasDividasTotais();
}