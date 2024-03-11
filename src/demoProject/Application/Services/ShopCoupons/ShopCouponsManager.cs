using Application.Features.ShopCoupons.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.ShopCoupons;

public class ShopCouponsManager : IShopCouponsService
{
    private readonly IShopCouponRepository _shopCouponRepository;
    private readonly ShopCouponBusinessRules _shopCouponBusinessRules;

    public ShopCouponsManager(IShopCouponRepository shopCouponRepository, ShopCouponBusinessRules shopCouponBusinessRules)
    {
        _shopCouponRepository = shopCouponRepository;
        _shopCouponBusinessRules = shopCouponBusinessRules;
    }

    public async Task<ShopCoupon?> GetAsync(
        Expression<Func<ShopCoupon, bool>> predicate,
        Func<IQueryable<ShopCoupon>, IIncludableQueryable<ShopCoupon, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        ShopCoupon? shopCoupon = await _shopCouponRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return shopCoupon;
    }

    public async Task<IPaginate<ShopCoupon>?> GetListAsync(
        Expression<Func<ShopCoupon, bool>>? predicate = null,
        Func<IQueryable<ShopCoupon>, IOrderedQueryable<ShopCoupon>>? orderBy = null,
        Func<IQueryable<ShopCoupon>, IIncludableQueryable<ShopCoupon, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<ShopCoupon> shopCouponList = await _shopCouponRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return shopCouponList;
    }

    public async Task<ShopCoupon> AddAsync(ShopCoupon shopCoupon)
    {
        ShopCoupon addedShopCoupon = await _shopCouponRepository.AddAsync(shopCoupon);

        return addedShopCoupon;
    }

    public async Task<ShopCoupon> UpdateAsync(ShopCoupon shopCoupon)
    {
        ShopCoupon updatedShopCoupon = await _shopCouponRepository.UpdateAsync(shopCoupon);

        return updatedShopCoupon;
    }

    public async Task<ShopCoupon> DeleteAsync(ShopCoupon shopCoupon, bool permanent = false)
    {
        ShopCoupon deletedShopCoupon = await _shopCouponRepository.DeleteAsync(shopCoupon);

        return deletedShopCoupon;
    }
}
