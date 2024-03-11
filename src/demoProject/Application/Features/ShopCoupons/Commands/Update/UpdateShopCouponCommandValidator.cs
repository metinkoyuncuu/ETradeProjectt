using FluentValidation;

namespace Application.Features.ShopCoupons.Commands.Update;

public class UpdateShopCouponCommandValidator : AbstractValidator<UpdateShopCouponCommand>
{
    public UpdateShopCouponCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.CouponId).NotEmpty();
        RuleFor(c => c.ShopId).NotEmpty();
    }
}