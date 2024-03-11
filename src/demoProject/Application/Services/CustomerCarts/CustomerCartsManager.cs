using Application.Features.CustomerCarts.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.CustomerCarts;

public class CustomerCartsManager : ICustomerCartsService
{
    private readonly ICustomerCartRepository _customerCartRepository;
    private readonly CustomerCartBusinessRules _customerCartBusinessRules;

    public CustomerCartsManager(ICustomerCartRepository customerCartRepository, CustomerCartBusinessRules customerCartBusinessRules)
    {
        _customerCartRepository = customerCartRepository;
        _customerCartBusinessRules = customerCartBusinessRules;
    }

    public async Task<CustomerCart?> GetAsync(
        Expression<Func<CustomerCart, bool>> predicate,
        Func<IQueryable<CustomerCart>, IIncludableQueryable<CustomerCart, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        CustomerCart? customerCart = await _customerCartRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return customerCart;
    }

    public async Task<IPaginate<CustomerCart>?> GetListAsync(
        Expression<Func<CustomerCart, bool>>? predicate = null,
        Func<IQueryable<CustomerCart>, IOrderedQueryable<CustomerCart>>? orderBy = null,
        Func<IQueryable<CustomerCart>, IIncludableQueryable<CustomerCart, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<CustomerCart> customerCartList = await _customerCartRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return customerCartList;
    }

    public async Task<CustomerCart> AddAsync(CustomerCart customerCart)
    {
        CustomerCart addedCustomerCart = await _customerCartRepository.AddAsync(customerCart);

        return addedCustomerCart;
    }

    public async Task<CustomerCart> UpdateAsync(CustomerCart customerCart)
    {
        CustomerCart updatedCustomerCart = await _customerCartRepository.UpdateAsync(customerCart);

        return updatedCustomerCart;
    }

    public async Task<CustomerCart> DeleteAsync(CustomerCart customerCart, bool permanent = false)
    {
        CustomerCart deletedCustomerCart = await _customerCartRepository.DeleteAsync(customerCart);

        return deletedCustomerCart;
    }
}
