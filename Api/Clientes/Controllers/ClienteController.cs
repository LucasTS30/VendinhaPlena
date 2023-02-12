using Api.Clientes.Services;
using Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.Clientes.Controller;

[ApiController]
[Route("/api/clientes")]
public class ClienteController : ControllerBase
{
    private readonly IClienteService _clienteService;

    public ClienteController(IClienteService clienteService)
    {
        _clienteService = clienteService;
    }

    [HttpGet]
    public IActionResult FindAll()
    {
        return Ok(_clienteService.FindAll());
    }

    [HttpGet("{id}")]
    public IActionResult FindById([FromRoute] int id)
    {
        return Ok(_clienteService.FindById(id));
    }

    [HttpPost]
    public IActionResult Create([FromBody] Cliente cliente)
    {
        var clienteFromBody = _clienteService.Create(cliente);
        return CreatedAtAction(nameof(FindById), new { Id = cliente.Id }, clienteFromBody);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateById([FromRoute] int id, [FromBody] Cliente cliente)
    {
        return Ok(_clienteService.UpdateById(id, cliente));
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteById([FromRoute] int id)
    {
        _clienteService.DeleteById(id);
        return NoContent();
    }

    [HttpGet("[action]/{name}")]
    public IActionResult FindByName([FromRoute] string name)
    {
        return Ok(_clienteService.FindByName(name));
    }

    [HttpGet("[action]")]
    public IActionResult FindAllComDividaEmAberto()
    {
        return Ok(_clienteService.FindAllComDividaEmAberto());
    }

    [HttpGet("[action]")]
    public IActionResult FindAllComIdade()
    {
        return Ok(_clienteService.FindAllComIdade());
    }

    [HttpGet("[action]/{id}")]
    public IActionResult SomaDasDividasPorClienteById([FromRoute] int id)
    {
        return Ok(_clienteService.SomaDasDividasPorClienteById(id));
    }

}