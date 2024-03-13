using Core.Application.Responses;
using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auth.Commands.ActivateAccount;
public class ActivateAccountResponse : IResponse
{
    public string Message { get; set; }
}
