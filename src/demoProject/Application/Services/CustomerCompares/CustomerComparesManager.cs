using Application.Features.CustomerCompares.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.CustomerCompares;

public class CustomerComparesManager : ICustomerComparesService
{
    private readonly ICustomerCompareRepository _customerCompareRepository;
    private readonly CustomerCompareBusinessRules _customerCompareBusinessRules;

    public CustomerComparesManager(ICustomerCompareRepository customerCompareRepository, CustomerCompareBusinessRules customerCompareBusinessRules)
    {
        _customerCompareRepository = customerCompareRepository;
        _customerCompareBusinessRules = customerCompareBusinessRules;
    }

    public async Task<CustomerCompare?> GetAsync(
        Expression<Func<CustomerCompare, bool>> predicate,
        Func<IQueryable<CustomerCompare>, IIncludableQueryable<CustomerCompare, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        CustomerCompare? customerCompare = await _customerCompareRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return customerCompare;
    }

    public async Task<IPaginate<CustomerCompare>?> GetListAsync(
        Expression<Func<CustomerCompare, bool>>? predicate = null,
        Func<IQueryable<CustomerCompare>, IOrderedQueryable<CustomerCompare>>? orderBy = null,
        Func<IQueryable<CustomerCompare>, IIncludableQueryable<CustomerCompare, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<CustomerCompare> customerCompareList = await _customerCompareRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return customerCompareList;
    }

    public async Task<CustomerCompare> AddAsync(CustomerCompare customerCompare)
    {
        CustomerCompare addedCustomerCompare = await _customerCompareRepository.AddAsync(customerCompare);

        return addedCustomerCompare;
    }

    public async Task<CustomerCompare> UpdateAsync(CustomerCompare customerCompare)
    {
        CustomerCompare updatedCustomerCompare = await _customerCompareRepository.UpdateAsync(customerCompare);

        return updatedCustomerCompare;
    }

    public async Task<CustomerCompare> DeleteAsync(CustomerCompare customerCompare, bool permanent = false)
    {
        CustomerCompare deletedCustomerCompare = await _customerCompareRepository.DeleteAsync(customerCompare);

        return deletedCustomerCompare;
    }
}
