using FluentValidation;

namespace Application.Features.ProductReviews.Commands.Create;

public class CreateProductReviewCommandValidator : AbstractValidator<CreateProductReviewCommand>
{
    public CreateProductReviewCommandValidator()
    {
        RuleFor(c => c.ProductId).NotEmpty();
        RuleFor(c => c.CustomerId).NotEmpty();
        RuleFor(c => c.Rate).NotEmpty();
        RuleFor(c => c.Comment).NotEmpty();
    }
}