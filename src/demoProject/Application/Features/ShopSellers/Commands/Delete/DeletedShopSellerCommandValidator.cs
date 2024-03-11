using FluentValidation;

namespace Application.Features.ShopSellers.Commands.Delete;

public class DeleteShopSellerCommandValidator : AbstractValidator<DeleteShopSellerCommand>
{
    public DeleteShopSellerCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}