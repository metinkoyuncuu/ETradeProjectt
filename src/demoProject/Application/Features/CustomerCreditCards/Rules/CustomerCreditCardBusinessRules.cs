using Application.Features.CustomerCreditCards.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.CustomerCreditCards.Rules;

public class CustomerCreditCardBusinessRules : BaseBusinessRules
{
    private readonly ICustomerCreditCardRepository _customerCreditCardRepository;

    public CustomerCreditCardBusinessRules(ICustomerCreditCardRepository customerCreditCardRepository)
    {
        _customerCreditCardRepository = customerCreditCardRepository;
    }

    public Task CustomerCreditCardShouldExistWhenSelected(CustomerCreditCard? customerCreditCard)
    {
        if (customerCreditCard == null)
            throw new BusinessException(CustomerCreditCardsBusinessMessages.CustomerCreditCardNotExists);
        return Task.CompletedTask;
    }

    public async Task CustomerCreditCardIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        CustomerCreditCard? customerCreditCard = await _customerCreditCardRepository.GetAsync(
            predicate: ccc => ccc.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await CustomerCreditCardShouldExistWhenSelected(customerCreditCard);
    }
}