using Application.Features.CustomerOrders.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.CustomerOrders;

public class CustomerOrdersManager : ICustomerOrdersService
{
    private readonly ICustomerOrderRepository _customerOrderRepository;
    private readonly CustomerOrderBusinessRules _customerOrderBusinessRules;

    public CustomerOrdersManager(ICustomerOrderRepository customerOrderRepository, CustomerOrderBusinessRules customerOrderBusinessRules)
    {
        _customerOrderRepository = customerOrderRepository;
        _customerOrderBusinessRules = customerOrderBusinessRules;
    }

    public async Task<CustomerOrder?> GetAsync(
        Expression<Func<CustomerOrder, bool>> predicate,
        Func<IQueryable<CustomerOrder>, IIncludableQueryable<CustomerOrder, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        CustomerOrder? customerOrder = await _customerOrderRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return customerOrder;
    }

    public async Task<IPaginate<CustomerOrder>?> GetListAsync(
        Expression<Func<CustomerOrder, bool>>? predicate = null,
        Func<IQueryable<CustomerOrder>, IOrderedQueryable<CustomerOrder>>? orderBy = null,
        Func<IQueryable<CustomerOrder>, IIncludableQueryable<CustomerOrder, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<CustomerOrder> customerOrderList = await _customerOrderRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return customerOrderList;
    }

    public async Task<CustomerOrder> AddAsync(CustomerOrder customerOrder)
    {
        CustomerOrder addedCustomerOrder = await _customerOrderRepository.AddAsync(customerOrder);

        return addedCustomerOrder;
    }

    public async Task<CustomerOrder> UpdateAsync(CustomerOrder customerOrder)
    {
        CustomerOrder updatedCustomerOrder = await _customerOrderRepository.UpdateAsync(customerOrder);

        return updatedCustomerOrder;
    }

    public async Task<CustomerOrder> DeleteAsync(CustomerOrder customerOrder, bool permanent = false)
    {
        CustomerOrder deletedCustomerOrder = await _customerOrderRepository.DeleteAsync(customerOrder);

        return deletedCustomerOrder;
    }
}
