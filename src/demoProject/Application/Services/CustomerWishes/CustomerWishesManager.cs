using Application.Features.CustomerWishes.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.CustomerWishes;

public class CustomerWishesManager : ICustomerWishesService
{
    private readonly ICustomerWishRepository _customerWishRepository;
    private readonly CustomerWishBusinessRules _customerWishBusinessRules;

    public CustomerWishesManager(ICustomerWishRepository customerWishRepository, CustomerWishBusinessRules customerWishBusinessRules)
    {
        _customerWishRepository = customerWishRepository;
        _customerWishBusinessRules = customerWishBusinessRules;
    }

    public async Task<CustomerWish?> GetAsync(
        Expression<Func<CustomerWish, bool>> predicate,
        Func<IQueryable<CustomerWish>, IIncludableQueryable<CustomerWish, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        CustomerWish? customerWish = await _customerWishRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return customerWish;
    }

    public async Task<IPaginate<CustomerWish>?> GetListAsync(
        Expression<Func<CustomerWish, bool>>? predicate = null,
        Func<IQueryable<CustomerWish>, IOrderedQueryable<CustomerWish>>? orderBy = null,
        Func<IQueryable<CustomerWish>, IIncludableQueryable<CustomerWish, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<CustomerWish> customerWishList = await _customerWishRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return customerWishList;
    }

    public async Task<CustomerWish> AddAsync(CustomerWish customerWish)
    {
        CustomerWish addedCustomerWish = await _customerWishRepository.AddAsync(customerWish);

        return addedCustomerWish;
    }

    public async Task<CustomerWish> UpdateAsync(CustomerWish customerWish)
    {
        CustomerWish updatedCustomerWish = await _customerWishRepository.UpdateAsync(customerWish);

        return updatedCustomerWish;
    }

    public async Task<CustomerWish> DeleteAsync(CustomerWish customerWish, bool permanent = false)
    {
        CustomerWish deletedCustomerWish = await _customerWishRepository.DeleteAsync(customerWish);

        return deletedCustomerWish;
    }
}
