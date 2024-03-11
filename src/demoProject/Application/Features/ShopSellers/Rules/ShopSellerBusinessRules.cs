using Application.Features.ShopSellers.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.ShopSellers.Rules;

public class ShopSellerBusinessRules : BaseBusinessRules
{
    private readonly IShopSellerRepository _shopSellerRepository;

    public ShopSellerBusinessRules(IShopSellerRepository shopSellerRepository)
    {
        _shopSellerRepository = shopSellerRepository;
    }

    public Task ShopSellerShouldExistWhenSelected(ShopSeller? shopSeller)
    {
        if (shopSeller == null)
            throw new BusinessException(ShopSellersBusinessMessages.ShopSellerNotExists);
        return Task.CompletedTask;
    }

    public async Task ShopSellerIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        ShopSeller? shopSeller = await _shopSellerRepository.GetAsync(
            predicate: ss => ss.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await ShopSellerShouldExistWhenSelected(shopSeller);
    }
}