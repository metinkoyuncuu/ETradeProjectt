using FluentValidation;

namespace Application.Features.CustomerAddresses.Commands.Delete;

public class DeleteCustomerAddressCommandValidator : AbstractValidator<DeleteCustomerAddressCommand>
{
    public DeleteCustomerAddressCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}