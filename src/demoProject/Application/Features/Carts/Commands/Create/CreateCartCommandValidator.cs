using FluentValidation;

namespace Application.Features.Carts.Commands.Create;

public class CreateCartCommandValidator : AbstractValidator<CreateCartCommand>
{
    public CreateCartCommandValidator()
    {
        RuleFor(c => c.CouponId).NotEmpty();
    }
}