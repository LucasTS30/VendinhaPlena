namespace Core.Repositories;

public interface IPagedRepository<Model>
{
    PagedResult<Model> FindAllComPaginacao(PaginationOptions options);
}