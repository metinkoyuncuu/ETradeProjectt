using FluentValidation;

namespace Application.Features.CustomerOrders.Commands.Create;

public class CreateCustomerOrderCommandValidator : AbstractValidator<CreateCustomerOrderCommand>
{
    public CreateCustomerOrderCommandValidator()
    {
        RuleFor(c => c.CustomerId).NotEmpty();
        RuleFor(c => c.OrderId).NotEmpty();
    }
}