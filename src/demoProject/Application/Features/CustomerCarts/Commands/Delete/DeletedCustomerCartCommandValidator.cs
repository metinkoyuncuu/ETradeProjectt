using FluentValidation;

namespace Application.Features.CustomerCarts.Commands.Delete;

public class DeleteCustomerCartCommandValidator : AbstractValidator<DeleteCustomerCartCommand>
{
    public DeleteCustomerCartCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}