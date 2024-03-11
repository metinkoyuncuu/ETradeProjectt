using FluentValidation;

namespace Application.Features.ProductFeatureTables.Commands.Create;

public class CreateProductFeatureTableCommandValidator : AbstractValidator<CreateProductFeatureTableCommand>
{
    public CreateProductFeatureTableCommandValidator()
    {
        RuleFor(c => c.Column).NotEmpty();
        RuleFor(c => c.Description).NotEmpty();
        RuleFor(c => c.ProductFeatureId).NotEmpty();
    }
}