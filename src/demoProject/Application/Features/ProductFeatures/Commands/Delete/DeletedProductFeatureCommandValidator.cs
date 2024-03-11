using FluentValidation;

namespace Application.Features.ProductFeatures.Commands.Delete;

public class DeleteProductFeatureCommandValidator : AbstractValidator<DeleteProductFeatureCommand>
{
    public DeleteProductFeatureCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}