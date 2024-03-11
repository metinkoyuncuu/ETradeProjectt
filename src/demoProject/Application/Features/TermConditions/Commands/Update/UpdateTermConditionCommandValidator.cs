using FluentValidation;

namespace Application.Features.TermConditions.Commands.Update;

public class UpdateTermConditionCommandValidator : AbstractValidator<UpdateTermConditionCommand>
{
    public UpdateTermConditionCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Header).NotEmpty();
        RuleFor(c => c.Text).NotEmpty();
    }
}