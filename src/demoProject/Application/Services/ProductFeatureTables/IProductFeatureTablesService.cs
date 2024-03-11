using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.ProductFeatureTables;

public interface IProductFeatureTablesService
{
    Task<ProductFeatureTable?> GetAsync(
        Expression<Func<ProductFeatureTable, bool>> predicate,
        Func<IQueryable<ProductFeatureTable>, IIncludableQueryable<ProductFeatureTable, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<ProductFeatureTable>?> GetListAsync(
        Expression<Func<ProductFeatureTable, bool>>? predicate = null,
        Func<IQueryable<ProductFeatureTable>, IOrderedQueryable<ProductFeatureTable>>? orderBy = null,
        Func<IQueryable<ProductFeatureTable>, IIncludableQueryable<ProductFeatureTable, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<ProductFeatureTable> AddAsync(ProductFeatureTable productFeatureTable);
    Task<ProductFeatureTable> UpdateAsync(ProductFeatureTable productFeatureTable);
    Task<ProductFeatureTable> DeleteAsync(ProductFeatureTable productFeatureTable, bool permanent = false);
}
