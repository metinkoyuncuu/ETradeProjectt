using Application.Features.Shippings.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Shippings;

public class ShippingsManager : IShippingsService
{
    private readonly IShippingRepository _shippingRepository;
    private readonly ShippingBusinessRules _shippingBusinessRules;

    public ShippingsManager(IShippingRepository shippingRepository, ShippingBusinessRules shippingBusinessRules)
    {
        _shippingRepository = shippingRepository;
        _shippingBusinessRules = shippingBusinessRules;
    }

    public async Task<Shipping?> GetAsync(
        Expression<Func<Shipping, bool>> predicate,
        Func<IQueryable<Shipping>, IIncludableQueryable<Shipping, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Shipping? shipping = await _shippingRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return shipping;
    }

    public async Task<IPaginate<Shipping>?> GetListAsync(
        Expression<Func<Shipping, bool>>? predicate = null,
        Func<IQueryable<Shipping>, IOrderedQueryable<Shipping>>? orderBy = null,
        Func<IQueryable<Shipping>, IIncludableQueryable<Shipping, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Shipping> shippingList = await _shippingRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return shippingList;
    }

    public async Task<Shipping> AddAsync(Shipping shipping)
    {
        Shipping addedShipping = await _shippingRepository.AddAsync(shipping);

        return addedShipping;
    }

    public async Task<Shipping> UpdateAsync(Shipping shipping)
    {
        Shipping updatedShipping = await _shippingRepository.UpdateAsync(shipping);

        return updatedShipping;
    }

    public async Task<Shipping> DeleteAsync(Shipping shipping, bool permanent = false)
    {
        Shipping deletedShipping = await _shippingRepository.DeleteAsync(shipping);

        return deletedShipping;
    }
}
