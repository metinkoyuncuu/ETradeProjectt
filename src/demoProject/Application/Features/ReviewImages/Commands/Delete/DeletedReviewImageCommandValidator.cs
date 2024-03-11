using FluentValidation;

namespace Application.Features.ReviewImages.Commands.Delete;

public class DeleteReviewImageCommandValidator : AbstractValidator<DeleteReviewImageCommand>
{
    public DeleteReviewImageCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}