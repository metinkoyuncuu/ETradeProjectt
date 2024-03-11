using FluentValidation;

namespace Application.Features.ProductTags.Commands.Delete;

public class DeleteProductTagCommandValidator : AbstractValidator<DeleteProductTagCommand>
{
    public DeleteProductTagCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}