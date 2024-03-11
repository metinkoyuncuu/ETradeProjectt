using FluentValidation;

namespace Application.Features.ProductVariants.Commands.Update;

public class UpdateProductVariantCommandValidator : AbstractValidator<UpdateProductVariantCommand>
{
    public UpdateProductVariantCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.ProductId).NotEmpty();
        RuleFor(c => c.ColorId).NotEmpty();
        RuleFor(c => c.QuantityInStock).NotEmpty();
        RuleFor(c => c.SizeId).NotEmpty();
    }
}