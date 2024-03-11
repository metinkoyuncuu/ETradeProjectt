using FluentValidation;

namespace Application.Features.CustomerOrders.Commands.Delete;

public class DeleteCustomerOrderCommandValidator : AbstractValidator<DeleteCustomerOrderCommand>
{
    public DeleteCustomerOrderCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}