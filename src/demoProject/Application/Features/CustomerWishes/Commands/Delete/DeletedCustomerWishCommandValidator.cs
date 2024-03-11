using FluentValidation;

namespace Application.Features.CustomerWishes.Commands.Delete;

public class DeleteCustomerWishCommandValidator : AbstractValidator<DeleteCustomerWishCommand>
{
    public DeleteCustomerWishCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}