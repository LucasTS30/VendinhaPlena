namespace Api.Dividas.DTOs;

public class PagarDividaDTO
{
    public float Valor { get; set; }
    public bool Situacao { get; set; }
    public DateTime? DataPagamento { get; set; }
}