using Api.Dividas.DTOs;
using Core.Models;

namespace Api.Dividas.Services;

public interface IDividaService
{
    ICollection<Divida> FindAll();
    Divida FindById(int id);
    Divida Create(Divida divida);
    Divida UpdateById(int id, Divida divida);
    void DeleteById(int id);
    float SomaDasDividasEmAberto();
    float SomaDasDividasTotais();
    void PagarDividaById(int id);

}