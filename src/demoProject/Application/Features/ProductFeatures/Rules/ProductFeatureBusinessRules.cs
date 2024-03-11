using Application.Features.ProductFeatures.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.ProductFeatures.Rules;

public class ProductFeatureBusinessRules : BaseBusinessRules
{
    private readonly IProductFeatureRepository _productFeatureRepository;

    public ProductFeatureBusinessRules(IProductFeatureRepository productFeatureRepository)
    {
        _productFeatureRepository = productFeatureRepository;
    }

    public Task ProductFeatureShouldExistWhenSelected(ProductFeature? productFeature)
    {
        if (productFeature == null)
            throw new BusinessException(ProductFeaturesBusinessMessages.ProductFeatureNotExists);
        return Task.CompletedTask;
    }

    public async Task ProductFeatureIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        ProductFeature? productFeature = await _productFeatureRepository.GetAsync(
            predicate: pf => pf.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await ProductFeatureShouldExistWhenSelected(productFeature);
    }
}