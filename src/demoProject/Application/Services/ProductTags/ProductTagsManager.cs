using Application.Features.ProductTags.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.ProductTags;

public class ProductTagsManager : IProductTagsService
{
    private readonly IProductTagRepository _productTagRepository;
    private readonly ProductTagBusinessRules _productTagBusinessRules;

    public ProductTagsManager(IProductTagRepository productTagRepository, ProductTagBusinessRules productTagBusinessRules)
    {
        _productTagRepository = productTagRepository;
        _productTagBusinessRules = productTagBusinessRules;
    }

    public async Task<ProductTag?> GetAsync(
        Expression<Func<ProductTag, bool>> predicate,
        Func<IQueryable<ProductTag>, IIncludableQueryable<ProductTag, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        ProductTag? productTag = await _productTagRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return productTag;
    }

    public async Task<IPaginate<ProductTag>?> GetListAsync(
        Expression<Func<ProductTag, bool>>? predicate = null,
        Func<IQueryable<ProductTag>, IOrderedQueryable<ProductTag>>? orderBy = null,
        Func<IQueryable<ProductTag>, IIncludableQueryable<ProductTag, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<ProductTag> productTagList = await _productTagRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return productTagList;
    }

    public async Task<ProductTag> AddAsync(ProductTag productTag)
    {
        ProductTag addedProductTag = await _productTagRepository.AddAsync(productTag);

        return addedProductTag;
    }

    public async Task<ProductTag> UpdateAsync(ProductTag productTag)
    {
        ProductTag updatedProductTag = await _productTagRepository.UpdateAsync(productTag);

        return updatedProductTag;
    }

    public async Task<ProductTag> DeleteAsync(ProductTag productTag, bool permanent = false)
    {
        ProductTag deletedProductTag = await _productTagRepository.DeleteAsync(productTag);

        return deletedProductTag;
    }
}
