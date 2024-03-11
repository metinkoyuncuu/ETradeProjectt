using FluentValidation;

namespace Application.Features.OrderProducts.Commands.Create;

public class CreateOrderProductCommandValidator : AbstractValidator<CreateOrderProductCommand>
{
    public CreateOrderProductCommandValidator()
    {
        RuleFor(c => c.OrderId).NotEmpty();
        RuleFor(c => c.ProductId).NotEmpty();
        RuleFor(c => c.Status).NotEmpty();
    }
}