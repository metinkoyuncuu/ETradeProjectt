using FluentValidation;

namespace Application.Features.ReviewImages.Commands.Create;

public class CreateReviewImageCommandValidator : AbstractValidator<CreateReviewImageCommand>
{
    public CreateReviewImageCommandValidator()
    {
        RuleFor(c => c.ProductReviewId).NotEmpty();
        RuleFor(c => c.ImageId).NotEmpty();
    }
}