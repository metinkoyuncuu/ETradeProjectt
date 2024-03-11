using Application.Features.ProductColors.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.ProductColors;

public class ProductColorsManager : IProductColorsService
{
    private readonly IProductColorRepository _productColorRepository;
    private readonly ProductColorBusinessRules _productColorBusinessRules;

    public ProductColorsManager(IProductColorRepository productColorRepository, ProductColorBusinessRules productColorBusinessRules)
    {
        _productColorRepository = productColorRepository;
        _productColorBusinessRules = productColorBusinessRules;
    }

    public async Task<ProductColor?> GetAsync(
        Expression<Func<ProductColor, bool>> predicate,
        Func<IQueryable<ProductColor>, IIncludableQueryable<ProductColor, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        ProductColor? productColor = await _productColorRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return productColor;
    }

    public async Task<IPaginate<ProductColor>?> GetListAsync(
        Expression<Func<ProductColor, bool>>? predicate = null,
        Func<IQueryable<ProductColor>, IOrderedQueryable<ProductColor>>? orderBy = null,
        Func<IQueryable<ProductColor>, IIncludableQueryable<ProductColor, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<ProductColor> productColorList = await _productColorRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return productColorList;
    }

    public async Task<ProductColor> AddAsync(ProductColor productColor)
    {
        ProductColor addedProductColor = await _productColorRepository.AddAsync(productColor);

        return addedProductColor;
    }

    public async Task<ProductColor> UpdateAsync(ProductColor productColor)
    {
        ProductColor updatedProductColor = await _productColorRepository.UpdateAsync(productColor);

        return updatedProductColor;
    }

    public async Task<ProductColor> DeleteAsync(ProductColor productColor, bool permanent = false)
    {
        ProductColor deletedProductColor = await _productColorRepository.DeleteAsync(productColor);

        return deletedProductColor;
    }
}
