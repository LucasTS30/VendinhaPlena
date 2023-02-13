using Api.Common.DTOs;
using Core.Models;
using Core.Repositories;

namespace Api.Clientes.Mappers;

public class ClienteMapper : IClienteMapper
{
    public PagedResponse<Cliente> ToPagedResponse(PagedResult<Cliente> pagedResult)
    {
        return new PagedResponse<Cliente>
        {
            Items = pagedResult.Items.ToList(),
            PageNumber = pagedResult.PageNumber,
            PageSize = pagedResult.PageSize,
            FirstPage = pagedResult.FirstPage,
            LastPage = pagedResult.LastPage,
            HasPreviousPage = pagedResult.HasPreviousPage,
            HasNextPage = pagedResult.HasNextPage,
            TotalPages = pagedResult.TotalPages,
            TotalElements = pagedResult.TotalElements
        };
    }
}