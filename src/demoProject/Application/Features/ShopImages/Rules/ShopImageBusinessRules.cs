using Application.Features.ShopImages.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.ShopImages.Rules;

public class ShopImageBusinessRules : BaseBusinessRules
{
    private readonly IShopImageRepository _shopImageRepository;

    public ShopImageBusinessRules(IShopImageRepository shopImageRepository)
    {
        _shopImageRepository = shopImageRepository;
    }

    public Task ShopImageShouldExistWhenSelected(ShopImage? shopImage)
    {
        if (shopImage == null)
            throw new BusinessException(ShopImagesBusinessMessages.ShopImageNotExists);
        return Task.CompletedTask;
    }

    public async Task ShopImageIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        ShopImage? shopImage = await _shopImageRepository.GetAsync(
            predicate: si => si.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await ShopImageShouldExistWhenSelected(shopImage);
    }
}