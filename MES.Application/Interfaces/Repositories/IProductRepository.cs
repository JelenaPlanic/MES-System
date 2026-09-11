using MES.Domain.Entities;
using MES.Application.QueryParameters;

namespace MES.Application.Interfaces;

public interface IProductRepository
{
    Task<PagedResult<Product>> GetPagedAsync(PaginationParameters parameters);
}
