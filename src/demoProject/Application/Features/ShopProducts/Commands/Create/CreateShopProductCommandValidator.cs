using FluentValidation;

namespace Application.Features.ShopProducts.Commands.Create;

public class CreateShopProductCommandValidator : AbstractValidator<CreateShopProductCommand>
{
    public CreateShopProductCommandValidator()
    {
        RuleFor(c => c.ProductId).NotEmpty();
        RuleFor(c => c.ShopId).NotEmpty();
    }
}