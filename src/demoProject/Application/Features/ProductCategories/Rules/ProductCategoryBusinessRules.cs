using Application.Features.ProductCategories.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.ProductCategories.Rules;

public class ProductCategoryBusinessRules : BaseBusinessRules
{
    private readonly IProductCategoryRepository _productCategoryRepository;

    public ProductCategoryBusinessRules(IProductCategoryRepository productCategoryRepository)
    {
        _productCategoryRepository = productCategoryRepository;
    }

    public Task ProductCategoryShouldExistWhenSelected(ProductCategory? productCategory)
    {
        if (productCategory == null)
            throw new BusinessException(ProductCategoriesBusinessMessages.ProductCategoryNotExists);
        return Task.CompletedTask;
    }

    public async Task ProductCategoryIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        ProductCategory? productCategory = await _productCategoryRepository.GetAsync(
            predicate: pc => pc.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await ProductCategoryShouldExistWhenSelected(productCategory);
    }
}