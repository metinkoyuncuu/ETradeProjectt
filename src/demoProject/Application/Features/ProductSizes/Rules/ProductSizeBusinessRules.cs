using Application.Features.ProductSizes.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.ProductSizes.Rules;

public class ProductSizeBusinessRules : BaseBusinessRules
{
    private readonly IProductSizeRepository _productSizeRepository;

    public ProductSizeBusinessRules(IProductSizeRepository productSizeRepository)
    {
        _productSizeRepository = productSizeRepository;
    }

    public Task ProductSizeShouldExistWhenSelected(ProductSize? productSize)
    {
        if (productSize == null)
            throw new BusinessException(ProductSizesBusinessMessages.ProductSizeNotExists);
        return Task.CompletedTask;
    }

    public async Task ProductSizeIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        ProductSize? productSize = await _productSizeRepository.GetAsync(
            predicate: ps => ps.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await ProductSizeShouldExistWhenSelected(productSize);
    }
}