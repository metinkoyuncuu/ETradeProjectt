using FluentValidation;

namespace Application.Features.ShopImages.Commands.Update;

public class UpdateShopImageCommandValidator : AbstractValidator<UpdateShopImageCommand>
{
    public UpdateShopImageCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.ShopId).NotEmpty();
        RuleFor(c => c.ImageId).NotEmpty();
        RuleFor(c => c.ImageType).NotEmpty();
    }
}