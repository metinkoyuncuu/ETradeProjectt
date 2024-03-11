using FluentValidation;

namespace Application.Features.CustomerCarts.Commands.Create;

public class CreateCustomerCartCommandValidator : AbstractValidator<CreateCustomerCartCommand>
{
    public CreateCustomerCartCommandValidator()
    {
        RuleFor(c => c.CustomerId).NotEmpty();
        RuleFor(c => c.ProductId).NotEmpty();
        RuleFor(c => c.CartId).NotEmpty();
        RuleFor(c => c.IsSelected).NotEmpty();
    }
}