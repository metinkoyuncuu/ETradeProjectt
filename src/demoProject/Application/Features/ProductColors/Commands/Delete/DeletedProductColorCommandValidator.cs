using FluentValidation;

namespace Application.Features.ProductColors.Commands.Delete;

public class DeleteProductColorCommandValidator : AbstractValidator<DeleteProductColorCommand>
{
    public DeleteProductColorCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}