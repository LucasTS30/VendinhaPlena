using Core.Models;

namespace Api.DTOs;

public class ClienteComIdadeDTO
{
    public int Idade { get; set; }
    public Cliente Cliente { get; set; } = null!;
}