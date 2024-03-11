using FluentValidation;

namespace Application.Features.ProductFeatureTables.Commands.Update;

public class UpdateProductFeatureTableCommandValidator : AbstractValidator<UpdateProductFeatureTableCommand>
{
    public UpdateProductFeatureTableCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Column).NotEmpty();
        RuleFor(c => c.Description).NotEmpty();
        RuleFor(c => c.ProductFeatureId).NotEmpty();
    }
}