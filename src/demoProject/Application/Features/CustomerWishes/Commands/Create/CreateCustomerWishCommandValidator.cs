using FluentValidation;

namespace Application.Features.CustomerWishes.Commands.Create;

public class CreateCustomerWishCommandValidator : AbstractValidator<CreateCustomerWishCommand>
{
    public CreateCustomerWishCommandValidator()
    {
        RuleFor(c => c.CustomerId).NotEmpty();
        RuleFor(c => c.ProductId).NotEmpty();
    }
}