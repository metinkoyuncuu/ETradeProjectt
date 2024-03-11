using FluentValidation;

namespace Application.Features.CustomerCoupons.Commands.Delete;

public class DeleteCustomerCouponCommandValidator : AbstractValidator<DeleteCustomerCouponCommand>
{
    public DeleteCustomerCouponCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}