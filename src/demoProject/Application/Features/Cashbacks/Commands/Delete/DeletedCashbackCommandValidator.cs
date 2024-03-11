using FluentValidation;

namespace Application.Features.Cashbacks.Commands.Delete;

public class DeleteCashbackCommandValidator : AbstractValidator<DeleteCashbackCommand>
{
    public DeleteCashbackCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}