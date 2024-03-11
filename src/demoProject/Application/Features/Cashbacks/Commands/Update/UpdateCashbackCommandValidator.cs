using FluentValidation;

namespace Application.Features.Cashbacks.Commands.Update;

public class UpdateCashbackCommandValidator : AbstractValidator<UpdateCashbackCommand>
{
    public UpdateCashbackCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.OrderId).NotEmpty();
        RuleFor(c => c.CustomerId).NotEmpty();
        RuleFor(c => c.CashbackRatio).NotEmpty();
    }
}