using Api.Common.DTOs;
using Core.Models;
using Core.Repositories;

namespace Api.Clientes.Mappers;

public interface IClienteMapper
{
    PagedResponse<Cliente> ToPagedResponse(PagedResult<Cliente> pagedResult);
}