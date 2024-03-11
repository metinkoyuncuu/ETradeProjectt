using FluentValidation;

namespace Application.Features.ReviewFeedbacks.Commands.Delete;

public class DeleteReviewFeedbackCommandValidator : AbstractValidator<DeleteReviewFeedbackCommand>
{
    public DeleteReviewFeedbackCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}