using FluentValidation;

namespace Application.Features.CustomerCoupons.Commands.Update;

public class UpdateCustomerCouponCommandValidator : AbstractValidator<UpdateCustomerCouponCommand>
{
    public UpdateCustomerCouponCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.CustomerId).NotEmpty();
        RuleFor(c => c.CouponId).NotEmpty();
    }
}