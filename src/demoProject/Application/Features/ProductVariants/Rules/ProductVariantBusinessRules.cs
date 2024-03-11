using Application.Features.ProductVariants.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.ProductVariants.Rules;

public class ProductVariantBusinessRules : BaseBusinessRules
{
    private readonly IProductVariantRepository _productVariantRepository;

    public ProductVariantBusinessRules(IProductVariantRepository productVariantRepository)
    {
        _productVariantRepository = productVariantRepository;
    }

    public Task ProductVariantShouldExistWhenSelected(ProductVariant? productVariant)
    {
        if (productVariant == null)
            throw new BusinessException(ProductVariantsBusinessMessages.ProductVariantNotExists);
        return Task.CompletedTask;
    }

    public async Task ProductVariantIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        ProductVariant? productVariant = await _productVariantRepository.GetAsync(
            predicate: pv => pv.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await ProductVariantShouldExistWhenSelected(productVariant);
    }
}