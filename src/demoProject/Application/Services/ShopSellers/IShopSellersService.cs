using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.ShopSellers;

public interface IShopSellersService
{
    Task<ShopSeller?> GetAsync(
        Expression<Func<ShopSeller, bool>> predicate,
        Func<IQueryable<ShopSeller>, IIncludableQueryable<ShopSeller, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<ShopSeller>?> GetListAsync(
        Expression<Func<ShopSeller, bool>>? predicate = null,
        Func<IQueryable<ShopSeller>, IOrderedQueryable<ShopSeller>>? orderBy = null,
        Func<IQueryable<ShopSeller>, IIncludableQueryable<ShopSeller, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<ShopSeller> AddAsync(ShopSeller shopSeller);
    Task<ShopSeller> UpdateAsync(ShopSeller shopSeller);
    Task<ShopSeller> DeleteAsync(ShopSeller shopSeller, bool permanent = false);
}
