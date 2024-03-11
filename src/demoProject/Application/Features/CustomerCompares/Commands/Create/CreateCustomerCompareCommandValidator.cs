using FluentValidation;

namespace Application.Features.CustomerCompares.Commands.Create;

public class CreateCustomerCompareCommandValidator : AbstractValidator<CreateCustomerCompareCommand>
{
    public CreateCustomerCompareCommandValidator()
    {
        RuleFor(c => c.CustomerId).NotEmpty();
        RuleFor(c => c.ProductId).NotEmpty();
    }
}