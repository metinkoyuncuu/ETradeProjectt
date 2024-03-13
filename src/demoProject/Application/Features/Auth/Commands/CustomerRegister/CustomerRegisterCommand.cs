using Application.Features.Auth.Commands.CustomerRegister;
using Application.Features.Auth.Rules;
using Application.Services.AuthService;
using Application.Services.Customers;
using Application.Services.Repositories;
using Core.Application.Dtos;
using Core.Security.Entities;
using Core.Security.Enums;
using Core.Security.Hashing;
using Core.Security.JWT;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auth.Commands.CustomerCustomerRegister;
public class CustomerRegisterCommand : IRequest<CustomerRegisteredResponse>
{
    public CustomerForRegisterDto CustomerForRegisterDto { get; set; }
    public string IpAddress { get; set; }

    public CustomerRegisterCommand()
    {
        CustomerForRegisterDto = null!;
        IpAddress = string.Empty;
    }

    public CustomerRegisterCommand(CustomerForRegisterDto customerForRegisterDto, string ipAddress)
    {
        CustomerForRegisterDto = customerForRegisterDto;
        IpAddress = ipAddress;
    }

    public class CustomerRegisterCommandHandler : IRequestHandler<CustomerRegisterCommand, CustomerRegisteredResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthService _authService;
        private readonly AuthBusinessRules _authBusinessRules;
        private readonly ICustomerRepository _customerRepository;
        public CustomerRegisterCommandHandler(IUserRepository userRepository, IAuthService authService, AuthBusinessRules authBusinessRules, ICustomerRepository customerRepository)
        {
            _userRepository = userRepository;
            _authService = authService;
            _authBusinessRules = authBusinessRules;
            _customerRepository = customerRepository;
        }

        public async Task<CustomerRegisteredResponse> Handle(CustomerRegisterCommand request, CancellationToken cancellationToken)
        {
            await _authBusinessRules.UserEmailShouldBeNotExists(request.CustomerForRegisterDto.Email);

            HashingHelper.CreatePasswordHash(
                request.CustomerForRegisterDto.Password,
                passwordHash: out byte[] passwordHash,
                passwordSalt: out byte[] passwordSalt
            );
            User newUser =
                new()
                {
                    Email = request.CustomerForRegisterDto.Email,
                    FirstName = request.CustomerForRegisterDto.FirstName,
                    LastName = request.CustomerForRegisterDto.LastName,
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                    AuthenticatorType=AuthenticatorType.Email,
                    Status = true,
                };
            User createdUser = await _userRepository.AddAsync(newUser);

            Customer customer = new() {UserId=createdUser.Id};
            await _customerRepository.AddAsync(customer);

            CustomerRegisteredResponse registeredResponse = new();
            return registeredResponse;
        }
    }
}
