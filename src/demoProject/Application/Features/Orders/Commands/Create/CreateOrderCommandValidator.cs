using FluentValidation;

namespace Application.Features.Orders.Commands.Create;

public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
{
    public CreateOrderCommandValidator()
    {
        RuleFor(c => c.TotalPrice).NotEmpty();
        RuleFor(c => c.OrderStatus).NotEmpty();
        RuleFor(c => c.PaymentMethod).NotEmpty();
        RuleFor(c => c.ShopId).NotEmpty();
        RuleFor(c => c.CustomerId).NotEmpty();
        RuleFor(c => c.CartId).NotEmpty();
    }
}