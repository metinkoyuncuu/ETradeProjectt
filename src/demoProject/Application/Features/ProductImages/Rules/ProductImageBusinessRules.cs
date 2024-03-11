using Application.Features.ProductImages.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.ProductImages.Rules;

public class ProductImageBusinessRules : BaseBusinessRules
{
    private readonly IProductImageRepository _productImageRepository;

    public ProductImageBusinessRules(IProductImageRepository productImageRepository)
    {
        _productImageRepository = productImageRepository;
    }

    public Task ProductImageShouldExistWhenSelected(ProductImage? productImage)
    {
        if (productImage == null)
            throw new BusinessException(ProductImagesBusinessMessages.ProductImageNotExists);
        return Task.CompletedTask;
    }

    public async Task ProductImageIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        ProductImage? productImage = await _productImageRepository.GetAsync(
            predicate: pi => pi.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await ProductImageShouldExistWhenSelected(productImage);
    }
}