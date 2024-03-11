using FluentValidation;

namespace Application.Features.ReviewFeedbacks.Commands.Create;

public class CreateReviewFeedbackCommandValidator : AbstractValidator<CreateReviewFeedbackCommand>
{
    public CreateReviewFeedbackCommandValidator()
    {
        RuleFor(c => c.ProductReviewId).NotEmpty();
        RuleFor(c => c.CustomerId).NotEmpty();
        RuleFor(c => c.Feedback).NotEmpty();
    }
}