using Application.Features.Shops.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.Shops.Rules;

public class ShopBusinessRules : BaseBusinessRules
{
    private readonly IShopRepository _shopRepository;

    public ShopBusinessRules(IShopRepository shopRepository)
    {
        _shopRepository = shopRepository;
    }

    public Task ShopShouldExistWhenSelected(Shop? shop)
    {
        if (shop == null)
            throw new BusinessException(ShopsBusinessMessages.ShopNotExists);
        return Task.CompletedTask;
    }

    public async Task ShopIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        Shop? shop = await _shopRepository.GetAsync(
            predicate: s => s.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await ShopShouldExistWhenSelected(shop);
    }
}