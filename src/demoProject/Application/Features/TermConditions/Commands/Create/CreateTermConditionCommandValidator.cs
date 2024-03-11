using FluentValidation;

namespace Application.Features.TermConditions.Commands.Create;

public class CreateTermConditionCommandValidator : AbstractValidator<CreateTermConditionCommand>
{
    public CreateTermConditionCommandValidator()
    {
        RuleFor(c => c.Header).NotEmpty();
        RuleFor(c => c.Text).NotEmpty();
    }
}