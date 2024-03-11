using FluentValidation;

namespace Application.Features.ProductColors.Commands.Create;

public class CreateProductColorCommandValidator : AbstractValidator<CreateProductColorCommand>
{
    public CreateProductColorCommandValidator()
    {
        RuleFor(c => c.ProductId).NotEmpty();
        RuleFor(c => c.ColorId).NotEmpty();
        RuleFor(c => c.QuantityInStock).NotEmpty();
        RuleFor(c => c.ImageId).NotEmpty();
    }
}