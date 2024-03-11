using FluentValidation;

namespace Application.Features.ReviewFeedbacks.Commands.Update;

public class UpdateReviewFeedbackCommandValidator : AbstractValidator<UpdateReviewFeedbackCommand>
{
    public UpdateReviewFeedbackCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.ProductReviewId).NotEmpty();
        RuleFor(c => c.CustomerId).NotEmpty();
        RuleFor(c => c.Feedback).NotEmpty();
    }
}