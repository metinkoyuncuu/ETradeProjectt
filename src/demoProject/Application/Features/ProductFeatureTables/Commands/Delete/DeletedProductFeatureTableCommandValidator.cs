using FluentValidation;

namespace Application.Features.ProductFeatureTables.Commands.Delete;

public class DeleteProductFeatureTableCommandValidator : AbstractValidator<DeleteProductFeatureTableCommand>
{
    public DeleteProductFeatureTableCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}