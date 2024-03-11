using FluentValidation;

namespace Application.Features.ProductQuestions.Commands.Create;

public class CreateProductQuestionCommandValidator : AbstractValidator<CreateProductQuestionCommand>
{
    public CreateProductQuestionCommandValidator()
    {
        RuleFor(c => c.ProductId).NotEmpty();
        RuleFor(c => c.CustomerId).NotEmpty();
        RuleFor(c => c.SellerId).NotEmpty();
        RuleFor(c => c.Question).NotEmpty();
        RuleFor(c => c.Answer).NotEmpty();
    }
}