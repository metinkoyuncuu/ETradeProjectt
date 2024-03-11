using FluentValidation;

namespace Application.Features.Sellers.Commands.Update;

public class UpdateSellerCommandValidator : AbstractValidator<UpdateSellerCommand>
{
    public UpdateSellerCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
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