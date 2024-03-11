using FluentValidation;

namespace Application.Features.TermConditions.Commands.Delete;

public class DeleteTermConditionCommandValidator : AbstractValidator<DeleteTermConditionCommand>
{
    public DeleteTermConditionCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}