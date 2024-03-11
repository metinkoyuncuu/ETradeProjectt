using FluentValidation;

namespace Application.Features.CustomerAddresses.Commands.Create;

public class CreateCustomerAddressCommandValidator : AbstractValidator<CreateCustomerAddressCommand>
{
    public CreateCustomerAddressCommandValidator()
    {
        RuleFor(c => c.CustomerId).NotEmpty();
        RuleFor(c => c.Header).NotEmpty();
        RuleFor(c => c.FirstName).NotEmpty();
        RuleFor(c => c.LastName).NotEmpty();
        RuleFor(c => c.PhoneNumber).NotEmpty();
        RuleFor(c => c.CityId).NotEmpty();
        RuleFor(c => c.DistrictId).NotEmpty();
        RuleFor(c => c.Address).NotEmpty();
    }
}