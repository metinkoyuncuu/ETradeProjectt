using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.ProductColors;

public interface IProductColorsService
{
    Task<ProductColor?> GetAsync(
        Expression<Func<ProductColor, bool>> predicate,
        Func<IQueryable<ProductColor>, IIncludableQueryable<ProductColor, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<ProductColor>?> GetListAsync(
        Expression<Func<ProductColor, bool>>? predicate = null,
        Func<IQueryable<ProductColor>, IOrderedQueryable<ProductColor>>? orderBy = null,
        Func<IQueryable<ProductColor>, IIncludableQueryable<ProductColor, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<ProductColor> AddAsync(ProductColor productColor);
    Task<ProductColor> UpdateAsync(ProductColor productColor);
    Task<ProductColor> DeleteAsync(ProductColor productColor, bool permanent = false);
}
