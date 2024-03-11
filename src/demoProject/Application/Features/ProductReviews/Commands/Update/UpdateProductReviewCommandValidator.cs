using FluentValidation;

namespace Application.Features.ProductReviews.Commands.Update;

public class UpdateProductReviewCommandValidator : AbstractValidator<UpdateProductReviewCommand>
{
    public UpdateProductReviewCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.ProductId).NotEmpty();
        RuleFor(c => c.CustomerId).NotEmpty();
        RuleFor(c => c.Rate).NotEmpty();
        RuleFor(c => c.Comment).NotEmpty();
    }
}