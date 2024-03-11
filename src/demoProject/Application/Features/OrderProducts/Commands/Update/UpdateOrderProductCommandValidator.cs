using FluentValidation;

namespace Application.Features.OrderProducts.Commands.Update;

public class UpdateOrderProductCommandValidator : AbstractValidator<UpdateOrderProductCommand>
{
    public UpdateOrderProductCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.OrderId).NotEmpty();
        RuleFor(c => c.ProductId).NotEmpty();
        RuleFor(c => c.Status).NotEmpty();
    }
}