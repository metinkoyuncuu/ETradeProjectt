using FluentValidation;

namespace Application.Features.Orders.Commands.Update;

public class UpdateOrderCommandValidator : AbstractValidator<UpdateOrderCommand>
{
    public UpdateOrderCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.TotalPrice).NotEmpty();
        RuleFor(c => c.OrderStatus).NotEmpty();
        RuleFor(c => c.PaymentMethod).NotEmpty();
        RuleFor(c => c.ShopId).NotEmpty();
        RuleFor(c => c.CustomerId).NotEmpty();
        RuleFor(c => c.CartId).NotEmpty();
    }
}