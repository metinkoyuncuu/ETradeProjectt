using FluentValidation;

namespace Application.Features.ShopSellers.Commands.Create;

public class CreateShopSellerCommandValidator : AbstractValidator<CreateShopSellerCommand>
{
    public CreateShopSellerCommandValidator()
    {
        RuleFor(c => c.ShopId).NotEmpty();
        RuleFor(c => c.SellerId).NotEmpty();
    }
}