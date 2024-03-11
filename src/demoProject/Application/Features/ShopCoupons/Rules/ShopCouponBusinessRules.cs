using Application.Features.ShopCoupons.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.ShopCoupons.Rules;

public class ShopCouponBusinessRules : BaseBusinessRules
{
    private readonly IShopCouponRepository _shopCouponRepository;

    public ShopCouponBusinessRules(IShopCouponRepository shopCouponRepository)
    {
        _shopCouponRepository = shopCouponRepository;
    }

    public Task ShopCouponShouldExistWhenSelected(ShopCoupon? shopCoupon)
    {
        if (shopCoupon == null)
            throw new BusinessException(ShopCouponsBusinessMessages.ShopCouponNotExists);
        return Task.CompletedTask;
    }

    public async Task ShopCouponIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        ShopCoupon? shopCoupon = await _shopCouponRepository.GetAsync(
            predicate: sc => sc.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await ShopCouponShouldExistWhenSelected(shopCoupon);
    }
}