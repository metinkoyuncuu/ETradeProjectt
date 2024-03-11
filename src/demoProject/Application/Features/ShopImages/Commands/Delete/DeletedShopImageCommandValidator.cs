using FluentValidation;

namespace Application.Features.ShopImages.Commands.Delete;

public class DeleteShopImageCommandValidator : AbstractValidator<DeleteShopImageCommand>
{
    public DeleteShopImageCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}