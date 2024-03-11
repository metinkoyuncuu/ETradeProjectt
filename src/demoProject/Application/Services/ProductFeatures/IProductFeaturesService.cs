using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.ProductFeatures;

public interface IProductFeaturesService
{
    Task<ProductFeature?> GetAsync(
        Expression<Func<ProductFeature, bool>> predicate,
        Func<IQueryable<ProductFeature>, IIncludableQueryable<ProductFeature, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<ProductFeature>?> GetListAsync(
        Expression<Func<ProductFeature, bool>>? predicate = null,
        Func<IQueryable<ProductFeature>, IOrderedQueryable<ProductFeature>>? orderBy = null,
        Func<IQueryable<ProductFeature>, IIncludableQueryable<ProductFeature, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<ProductFeature> AddAsync(ProductFeature productFeature);
    Task<ProductFeature> UpdateAsync(ProductFeature productFeature);
    Task<ProductFeature> DeleteAsync(ProductFeature productFeature, bool permanent = false);
}
