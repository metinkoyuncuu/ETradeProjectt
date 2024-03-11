using Application.Features.ProductColors.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.ProductColors.Rules;

public class ProductColorBusinessRules : BaseBusinessRules
{
    private readonly IProductColorRepository _productColorRepository;

    public ProductColorBusinessRules(IProductColorRepository productColorRepository)
    {
        _productColorRepository = productColorRepository;
    }

    public Task ProductColorShouldExistWhenSelected(ProductColor? productColor)
    {
        if (productColor == null)
            throw new BusinessException(ProductColorsBusinessMessages.ProductColorNotExists);
        return Task.CompletedTask;
    }

    public async Task ProductColorIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        ProductColor? productColor = await _productColorRepository.GetAsync(
            predicate: pc => pc.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await ProductColorShouldExistWhenSelected(productColor);
    }
}