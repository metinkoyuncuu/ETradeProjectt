using FluentValidation;

namespace Application.Features.Coupons.Commands.Update;

public class UpdateCouponCommandValidator : AbstractValidator<UpdateCouponCommand>
{
    public UpdateCouponCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
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