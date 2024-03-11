using FluentValidation;

namespace Application.Features.ProductSizes.Commands.Update;

public class UpdateProductSizeCommandValidator : AbstractValidator<UpdateProductSizeCommand>
{
    public UpdateProductSizeCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.ProductId).NotEmpty();
        RuleFor(c => c.SizeId).NotEmpty();
        RuleFor(c => c.QuantityInStock).NotEmpty();
    }
}