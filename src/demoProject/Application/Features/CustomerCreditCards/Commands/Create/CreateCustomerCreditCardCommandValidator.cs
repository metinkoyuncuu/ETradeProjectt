using FluentValidation;

namespace Application.Features.CustomerCreditCards.Commands.Create;

public class CreateCustomerCreditCardCommandValidator : AbstractValidator<CreateCustomerCreditCardCommand>
{
    public CreateCustomerCreditCardCommandValidator()
    {
        RuleFor(c => c.CustomerId).NotEmpty();
        RuleFor(c => c.CardType).NotEmpty();
        RuleFor(c => c.HolderName).NotEmpty();
        RuleFor(c => c.ExpireMonth).NotEmpty();
        RuleFor(c => c.ExpireYear).NotEmpty();
        RuleFor(c => c.CVV).NotEmpty();
        RuleFor(c => c.CardNumber).NotEmpty();
    }
}