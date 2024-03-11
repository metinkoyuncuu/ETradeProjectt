using FluentValidation;

namespace Application.Features.Products.Commands.Update;

public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
{
    public UpdateProductCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.SKU).NotEmpty();
        RuleFor(c => c.Title).NotEmpty();
        RuleFor(c => c.Description).NotEmpty();
        RuleFor(c => c.Price).NotEmpty();
        RuleFor(c => c.IsDiscounted).NotEmpty();
        RuleFor(c => c.DiscountType).NotEmpty();
        RuleFor(c => c.DiscountValue).NotEmpty();
        RuleFor(c => c.Weight).NotEmpty();
        RuleFor(c => c.QuantityInStock).NotEmpty();
        RuleFor(c => c.SubCategoryId).NotEmpty();
        RuleFor(c => c.ShipPrice).NotEmpty();
        RuleFor(c => c.BrandId).NotEmpty();
    }
}