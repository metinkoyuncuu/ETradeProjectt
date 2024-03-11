using Application.Features.ShopProducts.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.ShopProducts;

public class ShopProductsManager : IShopProductsService
{
    private readonly IShopProductRepository _shopProductRepository;
    private readonly ShopProductBusinessRules _shopProductBusinessRules;

    public ShopProductsManager(IShopProductRepository shopProductRepository, ShopProductBusinessRules shopProductBusinessRules)
    {
        _shopProductRepository = shopProductRepository;
        _shopProductBusinessRules = shopProductBusinessRules;
    }

    public async Task<ShopProduct?> GetAsync(
        Expression<Func<ShopProduct, bool>> predicate,
        Func<IQueryable<ShopProduct>, IIncludableQueryable<ShopProduct, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        ShopProduct? shopProduct = await _shopProductRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return shopProduct;
    }

    public async Task<IPaginate<ShopProduct>?> GetListAsync(
        Expression<Func<ShopProduct, bool>>? predicate = null,
        Func<IQueryable<ShopProduct>, IOrderedQueryable<ShopProduct>>? orderBy = null,
        Func<IQueryable<ShopProduct>, IIncludableQueryable<ShopProduct, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<ShopProduct> shopProductList = await _shopProductRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return shopProductList;
    }

    public async Task<ShopProduct> AddAsync(ShopProduct shopProduct)
    {
        ShopProduct addedShopProduct = await _shopProductRepository.AddAsync(shopProduct);

        return addedShopProduct;
    }

    public async Task<ShopProduct> UpdateAsync(ShopProduct shopProduct)
    {
        ShopProduct updatedShopProduct = await _shopProductRepository.UpdateAsync(shopProduct);

        return updatedShopProduct;
    }

    public async Task<ShopProduct> DeleteAsync(ShopProduct shopProduct, bool permanent = false)
    {
        ShopProduct deletedShopProduct = await _shopProductRepository.DeleteAsync(shopProduct);

        return deletedShopProduct;
    }
}
