using Application.Features.ProductFeatures.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.ProductFeatures;

public class ProductFeaturesManager : IProductFeaturesService
{
    private readonly IProductFeatureRepository _productFeatureRepository;
    private readonly ProductFeatureBusinessRules _productFeatureBusinessRules;

    public ProductFeaturesManager(IProductFeatureRepository productFeatureRepository, ProductFeatureBusinessRules productFeatureBusinessRules)
    {
        _productFeatureRepository = productFeatureRepository;
        _productFeatureBusinessRules = productFeatureBusinessRules;
    }

    public async Task<ProductFeature?> GetAsync(
        Expression<Func<ProductFeature, bool>> predicate,
        Func<IQueryable<ProductFeature>, IIncludableQueryable<ProductFeature, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        ProductFeature? productFeature = await _productFeatureRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return productFeature;
    }

    public async Task<IPaginate<ProductFeature>?> GetListAsync(
        Expression<Func<ProductFeature, bool>>? predicate = null,
        Func<IQueryable<ProductFeature>, IOrderedQueryable<ProductFeature>>? orderBy = null,
        Func<IQueryable<ProductFeature>, IIncludableQueryable<ProductFeature, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<ProductFeature> productFeatureList = await _productFeatureRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return productFeatureList;
    }

    public async Task<ProductFeature> AddAsync(ProductFeature productFeature)
    {
        ProductFeature addedProductFeature = await _productFeatureRepository.AddAsync(productFeature);

        return addedProductFeature;
    }

    public async Task<ProductFeature> UpdateAsync(ProductFeature productFeature)
    {
        ProductFeature updatedProductFeature = await _productFeatureRepository.UpdateAsync(productFeature);

        return updatedProductFeature;
    }

    public async Task<ProductFeature> DeleteAsync(ProductFeature productFeature, bool permanent = false)
    {
        ProductFeature deletedProductFeature = await _productFeatureRepository.DeleteAsync(productFeature);

        return deletedProductFeature;
    }
}
