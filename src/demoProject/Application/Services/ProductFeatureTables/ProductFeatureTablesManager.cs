using Application.Features.ProductFeatureTables.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.ProductFeatureTables;

public class ProductFeatureTablesManager : IProductFeatureTablesService
{
    private readonly IProductFeatureTableRepository _productFeatureTableRepository;
    private readonly ProductFeatureTableBusinessRules _productFeatureTableBusinessRules;

    public ProductFeatureTablesManager(IProductFeatureTableRepository productFeatureTableRepository, ProductFeatureTableBusinessRules productFeatureTableBusinessRules)
    {
        _productFeatureTableRepository = productFeatureTableRepository;
        _productFeatureTableBusinessRules = productFeatureTableBusinessRules;
    }

    public async Task<ProductFeatureTable?> GetAsync(
        Expression<Func<ProductFeatureTable, bool>> predicate,
        Func<IQueryable<ProductFeatureTable>, IIncludableQueryable<ProductFeatureTable, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        ProductFeatureTable? productFeatureTable = await _productFeatureTableRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return productFeatureTable;
    }

    public async Task<IPaginate<ProductFeatureTable>?> GetListAsync(
        Expression<Func<ProductFeatureTable, bool>>? predicate = null,
        Func<IQueryable<ProductFeatureTable>, IOrderedQueryable<ProductFeatureTable>>? orderBy = null,
        Func<IQueryable<ProductFeatureTable>, IIncludableQueryable<ProductFeatureTable, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<ProductFeatureTable> productFeatureTableList = await _productFeatureTableRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return productFeatureTableList;
    }

    public async Task<ProductFeatureTable> AddAsync(ProductFeatureTable productFeatureTable)
    {
        ProductFeatureTable addedProductFeatureTable = await _productFeatureTableRepository.AddAsync(productFeatureTable);

        return addedProductFeatureTable;
    }

    public async Task<ProductFeatureTable> UpdateAsync(ProductFeatureTable productFeatureTable)
    {
        ProductFeatureTable updatedProductFeatureTable = await _productFeatureTableRepository.UpdateAsync(productFeatureTable);

        return updatedProductFeatureTable;
    }

    public async Task<ProductFeatureTable> DeleteAsync(ProductFeatureTable productFeatureTable, bool permanent = false)
    {
        ProductFeatureTable deletedProductFeatureTable = await _productFeatureTableRepository.DeleteAsync(productFeatureTable);

        return deletedProductFeatureTable;
    }
}
