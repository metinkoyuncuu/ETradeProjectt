using FluentValidation;

namespace Application.Features.Shippings.Commands.Delete;

public class DeleteShippingCommandValidator : AbstractValidator<DeleteShippingCommand>
{
    public DeleteShippingCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}