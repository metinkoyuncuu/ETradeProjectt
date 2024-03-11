using FluentValidation;

namespace Application.Features.Carts.Commands.Update;

public class UpdateCartCommandValidator : AbstractValidator<UpdateCartCommand>
{
    public UpdateCartCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.CouponId).NotEmpty();
    }
}