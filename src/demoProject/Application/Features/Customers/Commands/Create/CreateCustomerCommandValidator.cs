using FluentValidation;

namespace Application.Features.Customers.Commands.Create;

public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
{
    public CreateCustomerCommandValidator()
    {
        RuleFor(c => c.PhoneNumber).NotEmpty();
        RuleFor(c => c.Balance).NotEmpty();
        RuleFor(c => c.BirthDate).NotEmpty();
        RuleFor(c => c.ImageId).NotEmpty();
        RuleFor(c => c.GenderId).NotEmpty();
        RuleFor(c => c.UserId).NotEmpty();
    }
}