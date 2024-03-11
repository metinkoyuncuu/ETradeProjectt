using FluentValidation;

namespace Application.Features.Shops.Commands.Create;

public class CreateShopCommandValidator : AbstractValidator<CreateShopCommand>
{
    public CreateShopCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.TaxNumber).NotEmpty();
        RuleFor(c => c.AccessKey).NotEmpty();
        RuleFor(c => c.Address).NotEmpty();
        RuleFor(c => c.IsVerified).NotEmpty();
        RuleFor(c => c.Balance).NotEmpty();
    }
}