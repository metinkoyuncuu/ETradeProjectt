using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.ShopCoupons;

public interface IShopCouponsService
{
    Task<ShopCoupon?> GetAsync(
        Expression<Func<ShopCoupon, bool>> predicate,
        Func<IQueryable<ShopCoupon>, IIncludableQueryable<ShopCoupon, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<ShopCoupon>?> GetListAsync(
        Expression<Func<ShopCoupon, bool>>? predicate = null,
        Func<IQueryable<ShopCoupon>, IOrderedQueryable<ShopCoupon>>? orderBy = null,
        Func<IQueryable<ShopCoupon>, IIncludableQueryable<ShopCoupon, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<ShopCoupon> AddAsync(ShopCoupon shopCoupon);
    Task<ShopCoupon> UpdateAsync(ShopCoupon shopCoupon);
    Task<ShopCoupon> DeleteAsync(ShopCoupon shopCoupon, bool permanent = false);
}
