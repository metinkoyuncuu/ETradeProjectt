using FluentValidation;

namespace Application.Features.ProductTags.Commands.Update;

public class UpdateProductTagCommandValidator : AbstractValidator<UpdateProductTagCommand>
{
    public UpdateProductTagCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.ProductId).NotEmpty();
        RuleFor(c => c.TagId).NotEmpty();
    }
}