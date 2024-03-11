using FluentValidation;

namespace Application.Features.CustomerWishes.Commands.Update;

public class UpdateCustomerWishCommandValidator : AbstractValidator<UpdateCustomerWishCommand>
{
    public UpdateCustomerWishCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.CustomerId).NotEmpty();
        RuleFor(c => c.ProductId).NotEmpty();
    }
}