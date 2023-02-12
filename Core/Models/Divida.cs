namespace Core.Models;

public class Divida
{
    public int Id { get; set; }
    public float Valor { get; set; }
    public bool Situacao { get; set; }
    public DateTime? DataPagamento { get; set; }
    public int ClienteId { get; set; }

    public Cliente Cliente { get; set; } = null!;
}