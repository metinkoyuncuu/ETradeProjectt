using Application.Features.CustomerOrders.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.CustomerOrders.Rules;

public class CustomerOrderBusinessRules : BaseBusinessRules
{
    private readonly ICustomerOrderRepository _customerOrderRepository;

    public CustomerOrderBusinessRules(ICustomerOrderRepository customerOrderRepository)
    {
        _customerOrderRepository = customerOrderRepository;
    }

    public Task CustomerOrderShouldExistWhenSelected(CustomerOrder? customerOrder)
    {
        if (customerOrder == null)
            throw new BusinessException(CustomerOrdersBusinessMessages.CustomerOrderNotExists);
        return Task.CompletedTask;
    }

    public async Task CustomerOrderIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        CustomerOrder? customerOrder = await _customerOrderRepository.GetAsync(
            predicate: co => co.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await CustomerOrderShouldExistWhenSelected(customerOrder);
    }
}