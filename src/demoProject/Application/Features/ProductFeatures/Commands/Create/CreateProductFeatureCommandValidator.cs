using FluentValidation;

namespace Application.Features.ProductFeatures.Commands.Create;

public class CreateProductFeatureCommandValidator : AbstractValidator<CreateProductFeatureCommand>
{
    public CreateProductFeatureCommandValidator()
    {
        RuleFor(c => c.ProductId).NotEmpty();
        RuleFor(c => c.Header).NotEmpty();
    }
}