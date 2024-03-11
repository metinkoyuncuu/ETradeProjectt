using FluentValidation;

namespace Application.Features.ProductColors.Commands.Update;

public class UpdateProductColorCommandValidator : AbstractValidator<UpdateProductColorCommand>
{
    public UpdateProductColorCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.ProductId).NotEmpty();
        RuleFor(c => c.ColorId).NotEmpty();
        RuleFor(c => c.QuantityInStock).NotEmpty();
        RuleFor(c => c.ImageId).NotEmpty();
    }
}