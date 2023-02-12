using Api.Dividas.DTOs;
using Core.Data.Contexts;
using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Core.Repositories.Dividas;

public class DividaRepository : IDividaRepository
{
    private readonly VendinhaPlenaDbContext _context;

    public DividaRepository(VendinhaPlenaDbContext context)
    {
        _context = context;
    }

    public bool ExistsDividaEmAbertoByClienteId(int id)
    {
        var dividaEmAberto = _context.Dividas.Where(d => d.ClienteId == id && d.Situacao == false).FirstOrDefault();
        if (dividaEmAberto is null)
        {
            return false;
        }
        return true;
    }

    public Divida Create(Divida model)
    {
        _context.Dividas.Add(model);
        _context.SaveChanges();
        return model;
    }

    public void DeleteById(int id)
    {
        var divida = _context.Dividas.Find(id);
        if (divida is not null)
        {
            _context.Dividas.Remove(divida);
            _context.SaveChanges();
        }
    }

    public bool ExistsById(int id)
    {
        return _context.Dividas.Any(d => d.Id == id);
    }

    public ICollection<Divida> FindAll()
    {
        return _context.Dividas.AsNoTracking().Include(d => d.Cliente).ToList();
    }

    public Divida? FindById(int id)
    {
        return _context.Dividas.AsNoTracking().Include(d => d.Cliente).FirstOrDefault(d => d.Id == id);
    }

    public void PagarDividaById(int id)
    {
        var dividaAPagar = _context.Dividas.Find(id);
        if (dividaAPagar is not null)
        {
            dividaAPagar.Situacao = true;
            dividaAPagar.DataPagamento = DateTime.Now;
            _context.SaveChanges();
        }
    }

    public float SomaDasDividasEmAberto()
    {
        return _context.Dividas.Where(d => d.Situacao == false).Sum(d => d.Valor);
    }

    public float SomaDasDividasTotais()
    {
        return _context.Dividas.Sum(d => d.Valor);
    }

    public Divida Update(Divida model)
    {
        _context.Dividas.Update(model);
        _context.SaveChanges();
        return model;
    }
}
