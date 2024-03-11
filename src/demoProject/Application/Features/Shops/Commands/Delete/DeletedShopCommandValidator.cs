using FluentValidation;

namespace Application.Features.Shops.Commands.Delete;

public class DeleteShopCommandValidator : AbstractValidator<DeleteShopCommand>
{
    public DeleteShopCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}