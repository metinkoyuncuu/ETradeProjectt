using FluentValidation;

namespace Application.Features.Shops.Commands.Update;

public class UpdateShopCommandValidator : AbstractValidator<UpdateShopCommand>
{
    public UpdateShopCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.TaxNumber).NotEmpty();
        RuleFor(c => c.AccessKey).NotEmpty();
        RuleFor(c => c.Address).NotEmpty();
        RuleFor(c => c.IsVerified).NotEmpty();
        RuleFor(c => c.Balance).NotEmpty();
    }
}