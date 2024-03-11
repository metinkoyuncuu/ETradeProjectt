using FluentValidation;

namespace Application.Features.ProductQuestions.Commands.Update;

public class UpdateProductQuestionCommandValidator : AbstractValidator<UpdateProductQuestionCommand>
{
    public UpdateProductQuestionCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.ProductId).NotEmpty();
        RuleFor(c => c.CustomerId).NotEmpty();
        RuleFor(c => c.SellerId).NotEmpty();
        RuleFor(c => c.Question).NotEmpty();
        RuleFor(c => c.Answer).NotEmpty();
    }
}