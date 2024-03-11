using Application.Features.ShopImages.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.ShopImages;

public class ShopImagesManager : IShopImagesService
{
    private readonly IShopImageRepository _shopImageRepository;
    private readonly ShopImageBusinessRules _shopImageBusinessRules;

    public ShopImagesManager(IShopImageRepository shopImageRepository, ShopImageBusinessRules shopImageBusinessRules)
    {
        _shopImageRepository = shopImageRepository;
        _shopImageBusinessRules = shopImageBusinessRules;
    }

    public async Task<ShopImage?> GetAsync(
        Expression<Func<ShopImage, bool>> predicate,
        Func<IQueryable<ShopImage>, IIncludableQueryable<ShopImage, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        ShopImage? shopImage = await _shopImageRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return shopImage;
    }

    public async Task<IPaginate<ShopImage>?> GetListAsync(
        Expression<Func<ShopImage, bool>>? predicate = null,
        Func<IQueryable<ShopImage>, IOrderedQueryable<ShopImage>>? orderBy = null,
        Func<IQueryable<ShopImage>, IIncludableQueryable<ShopImage, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<ShopImage> shopImageList = await _shopImageRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return shopImageList;
    }

    public async Task<ShopImage> AddAsync(ShopImage shopImage)
    {
        ShopImage addedShopImage = await _shopImageRepository.AddAsync(shopImage);

        return addedShopImage;
    }

    public async Task<ShopImage> UpdateAsync(ShopImage shopImage)
    {
        ShopImage updatedShopImage = await _shopImageRepository.UpdateAsync(shopImage);

        return updatedShopImage;
    }

    public async Task<ShopImage> DeleteAsync(ShopImage shopImage, bool permanent = false)
    {
        ShopImage deletedShopImage = await _shopImageRepository.DeleteAsync(shopImage);

        return deletedShopImage;
    }
}
