using FluentValidation;

namespace Application.Features.Sellers.Commands.Delete;

public class DeleteSellerCommandValidator : AbstractValidator<DeleteSellerCommand>
{
    public DeleteSellerCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}