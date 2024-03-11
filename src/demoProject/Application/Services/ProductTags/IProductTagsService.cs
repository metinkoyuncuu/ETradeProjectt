using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.ProductTags;

public interface IProductTagsService
{
    Task<ProductTag?> GetAsync(
        Expression<Func<ProductTag, bool>> predicate,
        Func<IQueryable<ProductTag>, IIncludableQueryable<ProductTag, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<ProductTag>?> GetListAsync(
        Expression<Func<ProductTag, bool>>? predicate = null,
        Func<IQueryable<ProductTag>, IOrderedQueryable<ProductTag>>? orderBy = null,
        Func<IQueryable<ProductTag>, IIncludableQueryable<ProductTag, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<ProductTag> AddAsync(ProductTag productTag);
    Task<ProductTag> UpdateAsync(ProductTag productTag);
    Task<ProductTag> DeleteAsync(ProductTag productTag, bool permanent = false);
}
