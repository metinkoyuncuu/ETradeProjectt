using FluentValidation;

namespace Application.Features.CustomerOrders.Commands.Update;

public class UpdateCustomerOrderCommandValidator : AbstractValidator<UpdateCustomerOrderCommand>
{
    public UpdateCustomerOrderCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.CustomerId).NotEmpty();
        RuleFor(c => c.OrderId).NotEmpty();
    }
}