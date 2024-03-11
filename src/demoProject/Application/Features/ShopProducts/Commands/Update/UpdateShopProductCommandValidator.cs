using FluentValidation;

namespace Application.Features.ShopProducts.Commands.Update;

public class UpdateShopProductCommandValidator : AbstractValidator<UpdateShopProductCommand>
{
    public UpdateShopProductCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.ProductId).NotEmpty();
        RuleFor(c => c.ShopId).NotEmpty();
    }
}