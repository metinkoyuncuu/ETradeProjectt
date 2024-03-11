using FluentValidation;

namespace Application.Features.Sizes.Commands.Update;

public class UpdateSizeCommandValidator : AbstractValidator<UpdateSizeCommand>
{
    public UpdateSizeCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.IsVerified).NotEmpty();
    }
}