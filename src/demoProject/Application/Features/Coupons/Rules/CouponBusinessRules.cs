using Application.Features.Coupons.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.Coupons.Rules;

public class CouponBusinessRules : BaseBusinessRules
{
    private readonly ICouponRepository _couponRepository;

    public CouponBusinessRules(ICouponRepository couponRepository)
    {
        _couponRepository = couponRepository;
    }

    public Task CouponShouldExistWhenSelected(Coupon? coupon)
    {
        if (coupon == null)
            throw new BusinessException(CouponsBusinessMessages.CouponNotExists);
        return Task.CompletedTask;
    }

    public async Task CouponIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        Coupon? coupon = await _couponRepository.GetAsync(
            predicate: c => c.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await CouponShouldExistWhenSelected(coupon);
    }
}