using FluentValidation;

namespace Application.Features.ReviewImages.Commands.Update;

public class UpdateReviewImageCommandValidator : AbstractValidator<UpdateReviewImageCommand>
{
    public UpdateReviewImageCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.ProductReviewId).NotEmpty();
        RuleFor(c => c.ImageId).NotEmpty();
    }
}