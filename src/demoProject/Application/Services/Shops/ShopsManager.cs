using Application.Features.Shops.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Shops;

public class ShopsManager : IShopsService
{
    private readonly IShopRepository _shopRepository;
    private readonly ShopBusinessRules _shopBusinessRules;

    public ShopsManager(IShopRepository shopRepository, ShopBusinessRules shopBusinessRules)
    {
        _shopRepository = shopRepository;
        _shopBusinessRules = shopBusinessRules;
    }

    public async Task<Shop?> GetAsync(
        Expression<Func<Shop, bool>> predicate,
        Func<IQueryable<Shop>, IIncludableQueryable<Shop, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Shop? shop = await _shopRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return shop;
    }

    public async Task<IPaginate<Shop>?> GetListAsync(
        Expression<Func<Shop, bool>>? predicate = null,
        Func<IQueryable<Shop>, IOrderedQueryable<Shop>>? orderBy = null,
        Func<IQueryable<Shop>, IIncludableQueryable<Shop, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Shop> shopList = await _shopRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return shopList;
    }

    public async Task<Shop> AddAsync(Shop shop)
    {
        Shop addedShop = await _shopRepository.AddAsync(shop);

        return addedShop;
    }

    public async Task<Shop> UpdateAsync(Shop shop)
    {
        Shop updatedShop = await _shopRepository.UpdateAsync(shop);

        return updatedShop;
    }

    public async Task<Shop> DeleteAsync(Shop shop, bool permanent = false)
    {
        Shop deletedShop = await _shopRepository.DeleteAsync(shop);

        return deletedShop;
    }
}
