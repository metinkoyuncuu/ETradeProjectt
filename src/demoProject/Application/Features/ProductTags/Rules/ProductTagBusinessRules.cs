using Application.Features.ProductTags.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.ProductTags.Rules;

public class ProductTagBusinessRules : BaseBusinessRules
{
    private readonly IProductTagRepository _productTagRepository;

    public ProductTagBusinessRules(IProductTagRepository productTagRepository)
    {
        _productTagRepository = productTagRepository;
    }

    public Task ProductTagShouldExistWhenSelected(ProductTag? productTag)
    {
        if (productTag == null)
            throw new BusinessException(ProductTagsBusinessMessages.ProductTagNotExists);
        return Task.CompletedTask;
    }

    public async Task ProductTagIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        ProductTag? productTag = await _productTagRepository.GetAsync(
            predicate: pt => pt.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await ProductTagShouldExistWhenSelected(productTag);
    }
}