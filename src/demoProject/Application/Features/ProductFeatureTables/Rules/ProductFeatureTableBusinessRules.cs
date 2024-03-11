using Application.Features.ProductFeatureTables.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.ProductFeatureTables.Rules;

public class ProductFeatureTableBusinessRules : BaseBusinessRules
{
    private readonly IProductFeatureTableRepository _productFeatureTableRepository;

    public ProductFeatureTableBusinessRules(IProductFeatureTableRepository productFeatureTableRepository)
    {
        _productFeatureTableRepository = productFeatureTableRepository;
    }

    public Task ProductFeatureTableShouldExistWhenSelected(ProductFeatureTable? productFeatureTable)
    {
        if (productFeatureTable == null)
            throw new BusinessException(ProductFeatureTablesBusinessMessages.ProductFeatureTableNotExists);
        return Task.CompletedTask;
    }

    public async Task ProductFeatureTableIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        ProductFeatureTable? productFeatureTable = await _productFeatureTableRepository.GetAsync(
            predicate: pft => pft.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await ProductFeatureTableShouldExistWhenSelected(productFeatureTable);
    }
}