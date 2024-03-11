using Application.Features.ProductCategories.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.ProductCategories;

public class ProductCategoriesManager : IProductCategoriesService
{
    private readonly IProductCategoryRepository _productCategoryRepository;
    private readonly ProductCategoryBusinessRules _productCategoryBusinessRules;

    public ProductCategoriesManager(IProductCategoryRepository productCategoryRepository, ProductCategoryBusinessRules productCategoryBusinessRules)
    {
        _productCategoryRepository = productCategoryRepository;
        _productCategoryBusinessRules = productCategoryBusinessRules;
    }

    public async Task<ProductCategory?> GetAsync(
        Expression<Func<ProductCategory, bool>> predicate,
        Func<IQueryable<ProductCategory>, IIncludableQueryable<ProductCategory, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        ProductCategory? productCategory = await _productCategoryRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return productCategory;
    }

    public async Task<IPaginate<ProductCategory>?> GetListAsync(
        Expression<Func<ProductCategory, bool>>? predicate = null,
        Func<IQueryable<ProductCategory>, IOrderedQueryable<ProductCategory>>? orderBy = null,
        Func<IQueryable<ProductCategory>, IIncludableQueryable<ProductCategory, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<ProductCategory> productCategoryList = await _productCategoryRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return productCategoryList;
    }

    public async Task<ProductCategory> AddAsync(ProductCategory productCategory)
    {
        ProductCategory addedProductCategory = await _productCategoryRepository.AddAsync(productCategory);

        return addedProductCategory;
    }

    public async Task<ProductCategory> UpdateAsync(ProductCategory productCategory)
    {
        ProductCategory updatedProductCategory = await _productCategoryRepository.UpdateAsync(productCategory);

        return updatedProductCategory;
    }

    public async Task<ProductCategory> DeleteAsync(ProductCategory productCategory, bool permanent = false)
    {
        ProductCategory deletedProductCategory = await _productCategoryRepository.DeleteAsync(productCategory);

        return deletedProductCategory;
    }
}
