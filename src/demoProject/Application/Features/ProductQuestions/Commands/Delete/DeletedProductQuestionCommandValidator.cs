using FluentValidation;

namespace Application.Features.ProductQuestions.Commands.Delete;

public class DeleteProductQuestionCommandValidator : AbstractValidator<DeleteProductQuestionCommand>
{
    public DeleteProductQuestionCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}