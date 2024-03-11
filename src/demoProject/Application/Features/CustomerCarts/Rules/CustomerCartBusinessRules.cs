using Application.Features.CustomerCarts.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.CustomerCarts.Rules;

public class CustomerCartBusinessRules : BaseBusinessRules
{
    private readonly ICustomerCartRepository _customerCartRepository;

    public CustomerCartBusinessRules(ICustomerCartRepository customerCartRepository)
    {
        _customerCartRepository = customerCartRepository;
    }

    public Task CustomerCartShouldExistWhenSelected(CustomerCart? customerCart)
    {
        if (customerCart == null)
            throw new BusinessException(CustomerCartsBusinessMessages.CustomerCartNotExists);
        return Task.CompletedTask;
    }

    public async Task CustomerCartIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        CustomerCart? customerCart = await _customerCartRepository.GetAsync(
            predicate: cc => cc.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await CustomerCartShouldExistWhenSelected(customerCart);
    }
}