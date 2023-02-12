using Api.Dividas.DTOs;
using Core.Models;
using Core.Repositories.Dividas;

namespace Api.Dividas.Mappers;

public class DividaMapper : IDividaMapper
{
    private readonly IDividaRepository _dividaRepository;

    public DividaMapper(IDividaRepository dividaRepository)
    {
        _dividaRepository = dividaRepository;
    }

    // public DividaDTO ToDividaDTO(Divida divida)
    // {
    //     return new DividaDTO
    //     {
    //         Valor = divida.Valor,
    //         Situacao = divida.Situacao,
    //         DataPagamento = divida.DataPagamento,
    //         ClienteId = divida.ClienteId
    //     };
    // }

    // public Divida ToModel(DividaDTO dividaDTO)
    // {
    //     return new Divida
    //     {
    //         Id = dividaDTO.id
    //         Valor = dividaDTO.Valor,
    //         Situacao = dividaDTO.Situacao,
    //         DataPagamento = dividaDTO.DataPagamento,
    //         ClienteId = dividaDTO.ClienteId,
    //         Cliente = _dividaRepository.FindById(dividaDTO.ClienteId).Cliente
    //     };
    // }
}
