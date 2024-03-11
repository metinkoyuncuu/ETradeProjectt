using Application.Features.CustomerWishes.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.CustomerWishes.Rules;

public class CustomerWishBusinessRules : BaseBusinessRules
{
    private readonly ICustomerWishRepository _customerWishRepository;

    public CustomerWishBusinessRules(ICustomerWishRepository customerWishRepository)
    {
        _customerWishRepository = customerWishRepository;
    }

    public Task CustomerWishShouldExistWhenSelected(CustomerWish? customerWish)
    {
        if (customerWish == null)
            throw new BusinessException(CustomerWishesBusinessMessages.CustomerWishNotExists);
        return Task.CompletedTask;
    }

    public async Task CustomerWishIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        CustomerWish? customerWish = await _customerWishRepository.GetAsync(
            predicate: cw => cw.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await CustomerWishShouldExistWhenSelected(customerWish);
    }
}