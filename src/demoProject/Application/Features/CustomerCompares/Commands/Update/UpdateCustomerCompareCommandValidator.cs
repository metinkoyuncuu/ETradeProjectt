using FluentValidation;

namespace Application.Features.CustomerCompares.Commands.Update;

public class UpdateCustomerCompareCommandValidator : AbstractValidator<UpdateCustomerCompareCommand>
{
    public UpdateCustomerCompareCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.CustomerId).NotEmpty();
        RuleFor(c => c.ProductId).NotEmpty();
    }
}