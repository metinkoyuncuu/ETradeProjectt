using FluentValidation;

namespace Application.Features.ProductTags.Commands.Create;

public class CreateProductTagCommandValidator : AbstractValidator<CreateProductTagCommand>
{
    public CreateProductTagCommandValidator()
    {
        RuleFor(c => c.ProductId).NotEmpty();
        RuleFor(c => c.TagId).NotEmpty();
    }
}