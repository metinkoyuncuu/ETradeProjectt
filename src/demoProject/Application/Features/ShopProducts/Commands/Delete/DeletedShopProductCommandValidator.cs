using FluentValidation;

namespace Application.Features.ShopProducts.Commands.Delete;

public class DeleteShopProductCommandValidator : AbstractValidator<DeleteShopProductCommand>
{
    public DeleteShopProductCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}