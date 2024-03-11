using FluentValidation;

namespace Application.Features.Genders.Commands.Create;

public class CreateGenderCommandValidator : AbstractValidator<CreateGenderCommand>
{
    public CreateGenderCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
    }
}