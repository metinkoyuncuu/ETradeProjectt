using FluentValidation;

namespace Application.Features.Sizes.Commands.Create;

public class CreateSizeCommandValidator : AbstractValidator<CreateSizeCommand>
{
    public CreateSizeCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.IsVerified).NotEmpty();
    }
}