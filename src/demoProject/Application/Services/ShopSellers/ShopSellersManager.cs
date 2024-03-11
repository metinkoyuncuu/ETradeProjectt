using Application.Features.ShopSellers.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.ShopSellers;

public class ShopSellersManager : IShopSellersService
{
    private readonly IShopSellerRepository _shopSellerRepository;
    private readonly ShopSellerBusinessRules _shopSellerBusinessRules;

    public ShopSellersManager(IShopSellerRepository shopSellerRepository, ShopSellerBusinessRules shopSellerBusinessRules)
    {
        _shopSellerRepository = shopSellerRepository;
        _shopSellerBusinessRules = shopSellerBusinessRules;
    }

    public async Task<ShopSeller?> GetAsync(
        Expression<Func<ShopSeller, bool>> predicate,
        Func<IQueryable<ShopSeller>, IIncludableQueryable<ShopSeller, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        ShopSeller? shopSeller = await _shopSellerRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return shopSeller;
    }

    public async Task<IPaginate<ShopSeller>?> GetListAsync(
        Expression<Func<ShopSeller, bool>>? predicate = null,
        Func<IQueryable<ShopSeller>, IOrderedQueryable<ShopSeller>>? orderBy = null,
        Func<IQueryable<ShopSeller>, IIncludableQueryable<ShopSeller, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<ShopSeller> shopSellerList = await _shopSellerRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return shopSellerList;
    }

    public async Task<ShopSeller> AddAsync(ShopSeller shopSeller)
    {
        ShopSeller addedShopSeller = await _shopSellerRepository.AddAsync(shopSeller);

        return addedShopSeller;
    }

    public async Task<ShopSeller> UpdateAsync(ShopSeller shopSeller)
    {
        ShopSeller updatedShopSeller = await _shopSellerRepository.UpdateAsync(shopSeller);

        return updatedShopSeller;
    }

    public async Task<ShopSeller> DeleteAsync(ShopSeller shopSeller, bool permanent = false)
    {
        ShopSeller deletedShopSeller = await _shopSellerRepository.DeleteAsync(shopSeller);

        return deletedShopSeller;
    }
}
