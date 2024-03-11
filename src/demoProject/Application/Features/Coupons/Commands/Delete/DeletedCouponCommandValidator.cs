using FluentValidation;

namespace Application.Features.Coupons.Commands.Delete;

public class DeleteCouponCommandValidator : AbstractValidator<DeleteCouponCommand>
{
    public DeleteCouponCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}