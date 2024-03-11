using Application.Features.Coupons.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Coupons;

public class CouponsManager : ICouponsService
{
    private readonly ICouponRepository _couponRepository;
    private readonly CouponBusinessRules _couponBusinessRules;

    public CouponsManager(ICouponRepository couponRepository, CouponBusinessRules couponBusinessRules)
    {
        _couponRepository = couponRepository;
        _couponBusinessRules = couponBusinessRules;
    }

    public async Task<Coupon?> GetAsync(
        Expression<Func<Coupon, bool>> predicate,
        Func<IQueryable<Coupon>, IIncludableQueryable<Coupon, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Coupon? coupon = await _couponRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return coupon;
    }

    public async Task<IPaginate<Coupon>?> GetListAsync(
        Expression<Func<Coupon, bool>>? predicate = null,
        Func<IQueryable<Coupon>, IOrderedQueryable<Coupon>>? orderBy = null,
        Func<IQueryable<Coupon>, IIncludableQueryable<Coupon, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Coupon> couponList = await _couponRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return couponList;
    }

    public async Task<Coupon> AddAsync(Coupon coupon)
    {
        Coupon addedCoupon = await _couponRepository.AddAsync(coupon);

        return addedCoupon;
    }

    public async Task<Coupon> UpdateAsync(Coupon coupon)
    {
        Coupon updatedCoupon = await _couponRepository.UpdateAsync(coupon);

        return updatedCoupon;
    }

    public async Task<Coupon> DeleteAsync(Coupon coupon, bool permanent = false)
    {
        Coupon deletedCoupon = await _couponRepository.DeleteAsync(coupon);

        return deletedCoupon;
    }
}
