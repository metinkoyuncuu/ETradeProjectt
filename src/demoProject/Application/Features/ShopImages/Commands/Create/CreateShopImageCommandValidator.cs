using FluentValidation;

namespace Application.Features.ShopImages.Commands.Create;

public class CreateShopImageCommandValidator : AbstractValidator<CreateShopImageCommand>
{
    public CreateShopImageCommandValidator()
    {
        RuleFor(c => c.ShopId).NotEmpty();
        RuleFor(c => c.ImageId).NotEmpty();
        RuleFor(c => c.ImageType).NotEmpty();
    }
}