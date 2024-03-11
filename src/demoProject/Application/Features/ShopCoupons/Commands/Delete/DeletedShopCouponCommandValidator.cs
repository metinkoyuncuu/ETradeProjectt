using FluentValidation;

namespace Application.Features.ShopCoupons.Commands.Delete;

public class DeleteShopCouponCommandValidator : AbstractValidator<DeleteShopCouponCommand>
{
    public DeleteShopCouponCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}