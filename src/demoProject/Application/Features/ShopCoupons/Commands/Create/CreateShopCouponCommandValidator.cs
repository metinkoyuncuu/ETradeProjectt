using FluentValidation;

namespace Application.Features.ShopCoupons.Commands.Create;

public class CreateShopCouponCommandValidator : AbstractValidator<CreateShopCouponCommand>
{
    public CreateShopCouponCommandValidator()
    {
        RuleFor(c => c.CouponId).NotEmpty();
        RuleFor(c => c.ShopId).NotEmpty();
    }
}