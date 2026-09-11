using Microsoft.EntityFrameworkCore;
using MES.Application.Interfaces;
using MES.Application.QueryParameters;
using MES.Domain.Entities;

namespace MES.Infrastructure.Persistence.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext _context;

    public ProductRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<PagedResult<Product>> GetPagedAsync(PaginationParameters parameters)
    {
        var query = _context.Products.AsQueryable();

        query = parameters.SortBy?.ToLower() switch
        {
            "code" => parameters.SortDescending ? query.OrderByDescending(p => p.Code) : query.OrderBy(p => p.Code),
            "name" => parameters.SortDescending ? query.OrderByDescending(p => p.Name) : query.OrderBy(p => p.Name),
            _ => query.OrderBy(p => p.Id)
        };

        var totalCount = await query.CountAsync();

        var items = await query
            .Skip((parameters.PageNumber - 1) * parameters.PageSize)
            .Take(parameters.PageSize)
            .ToListAsync();

        return new PagedResult<Product>
        {
            Items = items,
            PageNumber = parameters.PageNumber,
            PageSize = parameters.PageSize,
            TotalCount = totalCount
        };
    }
}
