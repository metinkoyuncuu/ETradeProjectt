using FluentValidation;

namespace Application.Features.OrderProducts.Commands.Delete;

public class DeleteOrderProductCommandValidator : AbstractValidator<DeleteOrderProductCommand>
{
    public DeleteOrderProductCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}