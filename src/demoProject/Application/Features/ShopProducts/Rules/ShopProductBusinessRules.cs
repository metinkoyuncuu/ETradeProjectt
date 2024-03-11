using Application.Features.ShopProducts.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.ShopProducts.Rules;

public class ShopProductBusinessRules : BaseBusinessRules
{
    private readonly IShopProductRepository _shopProductRepository;

    public ShopProductBusinessRules(IShopProductRepository shopProductRepository)
    {
        _shopProductRepository = shopProductRepository;
    }

    public Task ShopProductShouldExistWhenSelected(ShopProduct? shopProduct)
    {
        if (shopProduct == null)
            throw new BusinessException(ShopProductsBusinessMessages.ShopProductNotExists);
        return Task.CompletedTask;
    }

    public async Task ShopProductIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        ShopProduct? shopProduct = await _shopProductRepository.GetAsync(
            predicate: sp => sp.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await ShopProductShouldExistWhenSelected(shopProduct);
    }
}