using FluentValidation;

namespace Application.Features.Bills.Commands.Delete;

public class DeleteBillCommandValidator : AbstractValidator<DeleteBillCommand>
{
    public DeleteBillCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}