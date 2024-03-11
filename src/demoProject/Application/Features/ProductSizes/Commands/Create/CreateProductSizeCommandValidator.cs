using FluentValidation;

namespace Application.Features.ProductSizes.Commands.Create;

public class CreateProductSizeCommandValidator : AbstractValidator<CreateProductSizeCommand>
{
    public CreateProductSizeCommandValidator()
    {
        RuleFor(c => c.ProductId).NotEmpty();
        RuleFor(c => c.SizeId).NotEmpty();
        RuleFor(c => c.QuantityInStock).NotEmpty();
    }
}