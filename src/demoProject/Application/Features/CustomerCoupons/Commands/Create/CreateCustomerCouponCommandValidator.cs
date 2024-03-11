using FluentValidation;

namespace Application.Features.CustomerCoupons.Commands.Create;

public class CreateCustomerCouponCommandValidator : AbstractValidator<CreateCustomerCouponCommand>
{
    public CreateCustomerCouponCommandValidator()
    {
        RuleFor(c => c.CustomerId).NotEmpty();
        RuleFor(c => c.CouponId).NotEmpty();
    }
}