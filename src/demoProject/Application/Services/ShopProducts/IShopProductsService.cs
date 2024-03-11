using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.ShopProducts;

public interface IShopProductsService
{
    Task<ShopProduct?> GetAsync(
        Expression<Func<ShopProduct, bool>> predicate,
        Func<IQueryable<ShopProduct>, IIncludableQueryable<ShopProduct, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<ShopProduct>?> GetListAsync(
        Expression<Func<ShopProduct, bool>>? predicate = null,
        Func<IQueryable<ShopProduct>, IOrderedQueryable<ShopProduct>>? orderBy = null,
        Func<IQueryable<ShopProduct>, IIncludableQueryable<ShopProduct, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<ShopProduct> AddAsync(ShopProduct shopProduct);
    Task<ShopProduct> UpdateAsync(ShopProduct shopProduct);
    Task<ShopProduct> DeleteAsync(ShopProduct shopProduct, bool permanent = false);
}
