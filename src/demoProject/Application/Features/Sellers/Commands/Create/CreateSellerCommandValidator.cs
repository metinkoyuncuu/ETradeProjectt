using FluentValidation;

namespace Application.Features.Sellers.Commands.Create;

public class CreateSellerCommandValidator : AbstractValidator<CreateSellerCommand>
{
    public CreateSellerCommandValidator()
    {
        RuleFor(c => c.UserId).NotEmpty();
        RuleFor(c => c.PersonalAddress).NotEmpty();
        RuleFor(c => c.Country).NotEmpty();
        RuleFor(c => c.PhoneNumber).NotEmpty();
        RuleFor(c => c.IdentityNumber).NotEmpty();
        RuleFor(c => c.ImageId).NotEmpty();
        RuleFor(c => c.IsVerified).NotEmpty();
        RuleFor(c => c.BirthDate).NotEmpty();
        RuleFor(c => c.GenderId).NotEmpty();
    }
}