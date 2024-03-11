using FluentValidation;

namespace Application.Features.ProductCategories.Commands.Create;

public class CreateProductCategoryCommandValidator : AbstractValidator<CreateProductCategoryCommand>
{
    public CreateProductCategoryCommandValidator()
    {
        RuleFor(c => c.ProductId).NotEmpty();
        RuleFor(c => c.CategoryId).NotEmpty();
    }
}