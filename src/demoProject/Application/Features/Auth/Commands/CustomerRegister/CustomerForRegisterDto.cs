using Core.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auth.Commands.CustomerRegister;
public class CustomerForRegisterDto
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string FirstName { get; set; }
    public string LastName{get; set;}
    public int? GenderId { get; set; }
    public CustomerForRegisterDto()
    {
        Email = string.Empty;
        Password = string.Empty;
        FirstName = string.Empty;
        LastName = string.Empty;
    }

    public CustomerForRegisterDto(string email, string password, string firstName, string lastName,int genderId)
    {
        Email = email;
        Password = password;
        FirstName = firstName;
        LastName = lastName;
        GenderId = genderId;
    }
}

