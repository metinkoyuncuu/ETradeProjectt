using FluentValidation;

namespace Application.Features.ShopSellers.Commands.Update;

public class UpdateShopSellerCommandValidator : AbstractValidator<UpdateShopSellerCommand>
{
    public UpdateShopSellerCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.ShopId).NotEmpty();
        RuleFor(c => c.SellerId).NotEmpty();
    }
}