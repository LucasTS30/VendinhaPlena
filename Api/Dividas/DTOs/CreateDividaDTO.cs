namespace Api.Dividas.DTOs;

public class CreateDividaDTO
{
    public float Valor { get; set; }
    public bool Situacao { get; set; }
    public DateTime? DataPagamento { get; set; }
    public int ClienteId { get; set; }
}