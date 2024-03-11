using FluentValidation;

namespace Application.Features.ProductCategories.Commands.Delete;

public class DeleteProductCategoryCommandValidator : AbstractValidator<DeleteProductCategoryCommand>
{
    public DeleteProductCategoryCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
    }
}