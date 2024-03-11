using Application.Features.CustomerAddresses.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.CustomerAddresses.Rules;

public class CustomerAddressBusinessRules : BaseBusinessRules
{
    private readonly ICustomerAddressRepository _customerAddressRepository;

    public CustomerAddressBusinessRules(ICustomerAddressRepository customerAddressRepository)
    {
        _customerAddressRepository = customerAddressRepository;
    }

    public Task CustomerAddressShouldExistWhenSelected(CustomerAddress? customerAddress)
    {
        if (customerAddress == null)
            throw new BusinessException(CustomerAddressesBusinessMessages.CustomerAddressNotExists);
        return Task.CompletedTask;
    }

    public async Task CustomerAddressIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        CustomerAddress? customerAddress = await _customerAddressRepository.GetAsync(
            predicate: ca => ca.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await CustomerAddressShouldExistWhenSelected(customerAddress);
    }
}