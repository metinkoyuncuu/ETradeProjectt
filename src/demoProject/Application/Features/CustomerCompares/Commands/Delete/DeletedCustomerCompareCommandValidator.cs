using FluentValidation;

namespace Application.Features.CustomerCompares.Commands.Delete;

public class DeleteCustomerCompareCommandValidator : AbstractValidator<DeleteCustomerCompareCommand>
{
    public DeleteCustomerCompareCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}