using Application.Features.Auth.Commands.CustomerCustomerRegister;
using Application.Features.Auth.Commands.Register;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auth.Commands.CustomerRegister;
public class CustomerRegisterCommandValidator : AbstractValidator<CustomerRegisterCommand>
{
    public CustomerRegisterCommandValidator()
    {
        RuleFor(c => c.CustomerForRegisterDto.FirstName).NotEmpty().MinimumLength(2);
        RuleFor(c => c.CustomerForRegisterDto.LastName).NotEmpty().MinimumLength(2);
        RuleFor(c => c.CustomerForRegisterDto.Email).NotEmpty().EmailAddress();
        RuleFor(c => c.CustomerForRegisterDto.Password).NotEmpty().MinimumLength(4);
    }
}
