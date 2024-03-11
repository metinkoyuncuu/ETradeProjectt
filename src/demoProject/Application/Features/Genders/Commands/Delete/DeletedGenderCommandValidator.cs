using FluentValidation;

namespace Application.Features.Genders.Commands.Delete;

public class DeleteGenderCommandValidator : AbstractValidator<DeleteGenderCommand>
{
    public DeleteGenderCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}