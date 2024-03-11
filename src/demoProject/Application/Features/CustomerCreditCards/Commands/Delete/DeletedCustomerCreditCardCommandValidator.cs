using FluentValidation;

namespace Application.Features.CustomerCreditCards.Commands.Delete;

public class DeleteCustomerCreditCardCommandValidator : AbstractValidator<DeleteCustomerCreditCardCommand>
{
    public DeleteCustomerCreditCardCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}