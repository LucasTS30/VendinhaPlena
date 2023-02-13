using System.Linq;
using Api.Clientes.Validators;
using Api.DTOs;
using Core.Data.Contexts;
using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Core.Repositories.Clientes;

public class ClienteRepository : IClienteRepository
{
    private readonly VendinhaPlenaDbContext _context;

    public ClienteRepository(VendinhaPlenaDbContext context)
    {
        _context = context;
    }

    public int CalculaIdade(DateTime dataNascimento)
    {
        if (dataNascimento < DateTime.Now)
        {
            int idade = DateTime.Now.Year - dataNascimento.Year;
            if (DateTime.Now.DayOfYear < dataNascimento.DayOfYear)
            {
                idade = idade - 1;
            }
            return idade;
        }
        return 0;
    }

    public Cliente Create(Cliente model)
    {
        _context.Clientes.Add(model);
        _context.SaveChanges();
        return model;
    }

    public void DeleteById(int id)
    {
        var cliente = _context.Clientes.Find(id);
        if (cliente is not null)
        {
            _context.Clientes.Remove(cliente);
            _context.SaveChanges();
        }
    }

    public bool ExistsById(int id)
    {
        return _context.Clientes.Any(c => c.Id == id);
    }

    public ICollection<Cliente> FindAll()
    {
        return _context.Clientes.AsNoTracking().Include(c => c.Dividas).OrderByDescending(c => c.Dividas.Max(d => d.Valor)).ToList();
    }

    // public PagedResult<Cliente> FindAllComPaginacao(PaginationOptions options)
    // {
    //     var totalElements = _context.Clientes.Count();
    //     var items = _context.Clientes
    //         .Skip((options.PageNumber - 1) * options.PageSize)
    //         .Take(options.PageSize).ToList();
    //     return new PagedResult<Cliente>(items, options.PageNumber, options.PageSize, totalElements);
    // }

    public ICollection<Cliente> FindAllComDividaEmAberto()
    {
        List<Cliente> clientes = 
            (from cliente in _context.Clientes
            join divida in _context.Dividas on cliente equals divida.Cliente
            where(divida.Situacao == false)
            orderby(divida.Valor) descending
            select cliente).ToList();

        return clientes;
    }

    public ICollection<ClienteComIdadeDTO> FindAllComIdade()
    {
        List<ClienteComIdadeDTO> clientesComIdade = new List<ClienteComIdadeDTO>();
        int idade = 0;
        var clientes = FindAll();
        foreach (var cliente in clientes)
        {
            idade = CalculaIdade(cliente.DataNascimento);
            var clienteComIdadeAdicionado = new ClienteComIdadeDTO
            {
                Idade = idade,
                Cliente = cliente
            };
            clientesComIdade.Add(clienteComIdadeAdicionado);
        }
        return clientesComIdade;
    }

    public Cliente? FindById(int id)
    {
        return _context.Clientes.AsNoTracking().Include(c => c.Dividas).FirstOrDefault(c => c.Id == id);
    }

    public ICollection<ClienteComIdadeDTO> FindByName(string name)
    {
        //return _context.Clientes.Where(c => c.NomeCompleto.Contains(name)).ToList();
        //var clientes = FindAllComIdade().Where(c => c.Cliente.NomeCompleto.Contains(name)).ToList();
        var clientesComIdade = FindAllComIdade();
        var clientesRetornadosDabusca = new List<ClienteComIdadeDTO>();
        foreach (var clienteComIdade in clientesComIdade)
        {
            if (clienteComIdade.Cliente.NomeCompleto.ToUpper().Contains(name.ToUpper()))
            {
                clientesRetornadosDabusca.Add(clienteComIdade);
            }
        }
        return clientesRetornadosDabusca;
    }

    public ICollection<Divida> ListarDividasClienteById(int id)
    {
        var dividas = new List<Divida>();
        var cliente = _context.Clientes.Find(id);
        if (cliente is not null)
        {
            dividas = _context.Dividas.Where(d => d.ClienteId == cliente.Id).ToList();
        }
        return dividas;
    }

    public double SomaDasDividasPorClienteById(int id)
    {
        var cliente = _context.Clientes.Find(id);
        double totalDivida = 0;
        if (cliente is not null)
        {
            totalDivida = _context.Dividas.Where(d => d.ClienteId == cliente.Id).Sum(d => d.Valor);
        }
        return totalDivida;
    }

    public Cliente Update(Cliente model)
    {
        _context.Clientes.Update(model);
        _context.SaveChanges();
        return model;
    }

    // public bool ValidaCpf(string cpf)
    // {
    //     return CpfValidator.IsCpf(cpf);
    // }
}