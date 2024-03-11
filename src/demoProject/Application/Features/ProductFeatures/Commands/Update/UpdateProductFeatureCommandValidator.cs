using FluentValidation;

namespace Application.Features.ProductFeatures.Commands.Update;

public class UpdateProductFeatureCommandValidator : AbstractValidator<UpdateProductFeatureCommand>
{
    public UpdateProductFeatureCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.ProductId).NotEmpty();
        RuleFor(c => c.Header).NotEmpty();
    }
}