using Application.Features.CustomerAddresses.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.CustomerAddresses;

public class CustomerAddressesManager : ICustomerAddressesService
{
    private readonly ICustomerAddressRepository _customerAddressRepository;
    private readonly CustomerAddressBusinessRules _customerAddressBusinessRules;

    public CustomerAddressesManager(ICustomerAddressRepository customerAddressRepository, CustomerAddressBusinessRules customerAddressBusinessRules)
    {
        _customerAddressRepository = customerAddressRepository;
        _customerAddressBusinessRules = customerAddressBusinessRules;
    }

    public async Task<CustomerAddress?> GetAsync(
        Expression<Func<CustomerAddress, bool>> predicate,
        Func<IQueryable<CustomerAddress>, IIncludableQueryable<CustomerAddress, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        CustomerAddress? customerAddress = await _customerAddressRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return customerAddress;
    }

    public async Task<IPaginate<CustomerAddress>?> GetListAsync(
        Expression<Func<CustomerAddress, bool>>? predicate = null,
        Func<IQueryable<CustomerAddress>, IOrderedQueryable<CustomerAddress>>? orderBy = null,
        Func<IQueryable<CustomerAddress>, IIncludableQueryable<CustomerAddress, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<CustomerAddress> customerAddressList = await _customerAddressRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return customerAddressList;
    }

    public async Task<CustomerAddress> AddAsync(CustomerAddress customerAddress)
    {
        CustomerAddress addedCustomerAddress = await _customerAddressRepository.AddAsync(customerAddress);

        return addedCustomerAddress;
    }

    public async Task<CustomerAddress> UpdateAsync(CustomerAddress customerAddress)
    {
        CustomerAddress updatedCustomerAddress = await _customerAddressRepository.UpdateAsync(customerAddress);

        return updatedCustomerAddress;
    }

    public async Task<CustomerAddress> DeleteAsync(CustomerAddress customerAddress, bool permanent = false)
    {
        CustomerAddress deletedCustomerAddress = await _customerAddressRepository.DeleteAsync(customerAddress);

        return deletedCustomerAddress;
    }
}
