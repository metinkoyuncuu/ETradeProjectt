using FluentValidation;

namespace Application.Features.CustomerCarts.Commands.Update;

public class UpdateCustomerCartCommandValidator : AbstractValidator<UpdateCustomerCartCommand>
{
    public UpdateCustomerCartCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.CustomerId).NotEmpty();
        RuleFor(c => c.ProductId).NotEmpty();
        RuleFor(c => c.CartId).NotEmpty();
        RuleFor(c => c.IsSelected).NotEmpty();
    }
}