using Api.Clientes.Services;
using Api.Dividas.DTOs;
using Api.Dividas.Services;
using Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.Dividas.Controllers;

[ApiController]
[Route("/api/dividas")]
public class DividaController : ControllerBase
{
    private readonly IDividaService _dividaService;
    private readonly IClienteService _clienteService;

    public DividaController(IDividaService dividaService, IClienteService clienteService)
    {
        _dividaService = dividaService;
        _clienteService = clienteService;
    }

    [HttpGet]
    public IActionResult FindAll()
    {
        return Ok(_dividaService.FindAll());
    }

    [HttpGet("{id}")]
    public IActionResult FindById([FromRoute] int id)
    {
        return Ok(_dividaService.FindById(id));
    }

    [HttpPost]
    public IActionResult Create([FromBody] CreateDividaDTO requestDivida)
    {
        var cliente = _clienteService.FindById(requestDivida.ClienteId);
        if (cliente is null)
        {
            return NotFound();
        }

        var newDivida = new Divida 
        {
            Valor = requestDivida.Valor,
            Situacao = requestDivida.Situacao,
            DataPagamento = requestDivida.DataPagamento,
            ClienteId = requestDivida.ClienteId
        };

        var dividaFromBody = _dividaService.Create(newDivida);
        return CreatedAtAction(nameof(FindById), new { Id = dividaFromBody.Id}, dividaFromBody);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateById([FromRoute] int id, [FromBody] CreateDividaDTO requestDivida)
    {
        var cliente = _clienteService.FindById(requestDivida.ClienteId);
        if (cliente is null)
        {
            return NotFound();
        }

        var dividaEditada = new Divida 
        {
            Valor = requestDivida.Valor,
            Situacao = requestDivida.Situacao,
            DataPagamento = requestDivida.DataPagamento,
            ClienteId = requestDivida.ClienteId
        };

        return Ok(_dividaService.UpdateById(id, dividaEditada));
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteById([FromRoute] int id)
    {
        _dividaService.DeleteById(id);
        return NoContent();
    }

    [HttpGet("[action]")]
    public IActionResult SomaDasDividasEmAberto()
    {
        return Ok(_dividaService.SomaDasDividasEmAberto());
    }

    [HttpGet("[action]")]
    public IActionResult SomaDasDividasTotais()
    {
        return Ok(_dividaService.SomaDasDividasTotais());
    }

    [HttpPatch("{id}")]
    public IActionResult PagarDividaById([FromRoute] int id)
    {
        _dividaService.PagarDividaById(id);
        return NoContent();
    }

}