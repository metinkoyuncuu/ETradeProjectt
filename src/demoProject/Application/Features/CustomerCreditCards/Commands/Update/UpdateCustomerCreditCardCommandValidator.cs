using FluentValidation;

namespace Application.Features.CustomerCreditCards.Commands.Update;

public class UpdateCustomerCreditCardCommandValidator : AbstractValidator<UpdateCustomerCreditCardCommand>
{
    public UpdateCustomerCreditCardCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.CustomerId).NotEmpty();
        RuleFor(c => c.CardType).NotEmpty();
        RuleFor(c => c.HolderName).NotEmpty();
        RuleFor(c => c.ExpireMonth).NotEmpty();
        RuleFor(c => c.ExpireYear).NotEmpty();
        RuleFor(c => c.CVV).NotEmpty();
        RuleFor(c => c.CardNumber).NotEmpty();
    }
}