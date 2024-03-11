using FluentValidation;

namespace Application.Features.Cashbacks.Commands.Create;

public class CreateCashbackCommandValidator : AbstractValidator<CreateCashbackCommand>
{
    public CreateCashbackCommandValidator()
    {
        RuleFor(c => c.OrderId).NotEmpty();
        RuleFor(c => c.CustomerId).NotEmpty();
        RuleFor(c => c.CashbackRatio).NotEmpty();
    }
}