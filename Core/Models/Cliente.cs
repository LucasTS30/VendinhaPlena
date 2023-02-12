using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Models;

public class Cliente
{
    public int Id { get; set; }
    public string NomeCompleto { get; set; } = null!;
    public string Cpf { get; set; } = null!;        
    public DateTime DataNascimento { get; set; }
    public string Email { get; set; } = null!;

    public ICollection<Divida> Dividas { get; set; } = new List<Divida>();
}