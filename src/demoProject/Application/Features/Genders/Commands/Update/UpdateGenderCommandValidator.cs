using FluentValidation;

namespace Application.Features.Genders.Commands.Update;

public class UpdateGenderCommandValidator : AbstractValidator<UpdateGenderCommand>
{
    public UpdateGenderCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
    }
}