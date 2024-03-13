using Application.Features.Auth.Commands.ActivateAccount;
using Application.Features.Auth.Commands.Login;
using Application.Features.Auth.Rules;
using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Mailing;
using Core.Security.EmailAuthenticator;
using Core.Security.Entities;
using Core.Security.Extensions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Distributed;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Auth.Commands.VerifyAccount
{
    public class ActivateAccountCommand : IRequest<ActivateAccountResponse>
    {
        public string? ActivationCode { get; set; }

        public ActivateAccountCommand(string? activationCode)
        {
            ActivationCode = activationCode;
        }

        public class ActivateAccountCommandHandler : IRequestHandler<ActivateAccountCommand, ActivateAccountResponse>
        {
            private readonly IUserRepository _userRepository;
            private readonly IHttpContextAccessor _httpContextAccessor;
            private readonly IEmailAuthenticatorHelper _emailAuthenticatorHelper;
            private readonly IMailService _mailService;
            private readonly AuthBusinessRules _authBusinessRules;
            private readonly IDistributedCache _cache;

            public ActivateAccountCommandHandler(IUserRepository userRepository, IHttpContextAccessor httpContextAccessor, IEmailAuthenticatorHelper emailAuthenticatorHelper, IMailService mailService, AuthBusinessRules authBusinessRules, IDistributedCache cache)
            {
                _userRepository = userRepository;
                _httpContextAccessor = httpContextAccessor;
                _emailAuthenticatorHelper = emailAuthenticatorHelper;
                _mailService = mailService;
                _authBusinessRules = authBusinessRules;
                _cache = cache;
            }

            public async Task<ActivateAccountResponse> Handle(ActivateAccountCommand request, CancellationToken cancellationToken)
            {
                int userId = _httpContextAccessor.HttpContext.User.GetUserId();
                User user = await _userRepository.GetAsync(u => u.Id == userId);
                await _authBusinessRules.AccountAlreadyActivated(user);

                string cacheKey = $"ActivationCode-{userId}";
                string activationCode;

                // Bu satırda ActivateAccountResponse nesnesini oluşturuyoruz.
                ActivateAccountResponse activationResponse = new ActivateAccountResponse();

                if (request.ActivationCode is null)
                {
                    // Generate new activation code
                    activationCode = await _emailAuthenticatorHelper.CreateEmailActivationCode();
                    var options = new DistributedCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(3));
                    await _cache.SetStringAsync(cacheKey, activationCode, options, cancellationToken);

                    // Send activation code via email
                    var toEmailList = new List<MailboxAddress> { new MailboxAddress($"{user.FirstName} {user.LastName}", user.Email) };

                    Mail mail = new Mail(
                        toList: toEmailList,
                        subject: "Pazarım Hesabınızı Aktifleştirin",
                        textBody: "Aktivasyon Kodunuz: " + activationCode,
                        htmlBody: null
                        );
                    await _mailService.SendEmailAsync(mail);

                    activationResponse.Message = "Activation code has been sent to your email.";
                    return activationResponse;
                }
                else
                {
                    activationCode = await _cache.GetStringAsync(cacheKey, cancellationToken);
                    if (activationCode == null || activationCode != request.ActivationCode)
                    {
                        throw new BusinessException("Activation code is invalid or expired.");
                    }

                    user.Status = true;
                    await _userRepository.UpdateAsync(user);
                    await _cache.RemoveAsync(cacheKey, cancellationToken);

                    activationResponse.Message = "Account has been activated successfully.";
                    return activationResponse;
                }
            }
        }
    }
}