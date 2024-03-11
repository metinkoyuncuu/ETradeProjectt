using FluentValidation;

namespace Application.Features.Coupons.Commands.Create;

public class CreateCouponCommandValidator : AbstractValidator<CreateCouponCommand>
{
    public CreateCouponCommandValidator()
    {
        RuleFor(c => c.Code).NotEmpty();
        RuleFor(c => c.Description).NotEmpty();
        RuleFor(c => c.DiscountType).NotEmpty();
        RuleFor(c => c.DiscountValue).NotEmpty();
        RuleFor(c => c.MinimumPurchase).NotEmpty();
        RuleFor(c => c.ApplicableToAllShops).NotEmpty();
        RuleFor(c => c.StartDate).NotEmpty();
        RuleFor(c => c.EndDate).NotEmpty();
        RuleFor(c => c.UsageLimit).NotEmpty();
        RuleFor(c => c.IsVerified).NotEmpty();
    }
}