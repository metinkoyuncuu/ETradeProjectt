using FluentValidation;

namespace Application.Features.Sizes.Commands.Delete;

public class DeleteSizeCommandValidator : AbstractValidator<DeleteSizeCommand>
{
    public DeleteSizeCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}