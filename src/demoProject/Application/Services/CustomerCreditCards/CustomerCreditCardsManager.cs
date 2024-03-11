using Application.Features.CustomerCreditCards.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.CustomerCreditCards;

public class CustomerCreditCardsManager : ICustomerCreditCardsService
{
    private readonly ICustomerCreditCardRepository _customerCreditCardRepository;
    private readonly CustomerCreditCardBusinessRules _customerCreditCardBusinessRules;

    public CustomerCreditCardsManager(ICustomerCreditCardRepository customerCreditCardRepository, CustomerCreditCardBusinessRules customerCreditCardBusinessRules)
    {
        _customerCreditCardRepository = customerCreditCardRepository;
        _customerCreditCardBusinessRules = customerCreditCardBusinessRules;
    }

    public async Task<CustomerCreditCard?> GetAsync(
        Expression<Func<CustomerCreditCard, bool>> predicate,
        Func<IQueryable<CustomerCreditCard>, IIncludableQueryable<CustomerCreditCard, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        CustomerCreditCard? customerCreditCard = await _customerCreditCardRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return customerCreditCard;
    }

    public async Task<IPaginate<CustomerCreditCard>?> GetListAsync(
        Expression<Func<CustomerCreditCard, bool>>? predicate = null,
        Func<IQueryable<CustomerCreditCard>, IOrderedQueryable<CustomerCreditCard>>? orderBy = null,
        Func<IQueryable<CustomerCreditCard>, IIncludableQueryable<CustomerCreditCard, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<CustomerCreditCard> customerCreditCardList = await _customerCreditCardRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return customerCreditCardList;
    }

    public async Task<CustomerCreditCard> AddAsync(CustomerCreditCard customerCreditCard)
    {
        CustomerCreditCard addedCustomerCreditCard = await _customerCreditCardRepository.AddAsync(customerCreditCard);

        return addedCustomerCreditCard;
    }

    public async Task<CustomerCreditCard> UpdateAsync(CustomerCreditCard customerCreditCard)
    {
        CustomerCreditCard updatedCustomerCreditCard = await _customerCreditCardRepository.UpdateAsync(customerCreditCard);

        return updatedCustomerCreditCard;
    }

    public async Task<CustomerCreditCard> DeleteAsync(CustomerCreditCard customerCreditCard, bool permanent = false)
    {
        CustomerCreditCard deletedCustomerCreditCard = await _customerCreditCardRepository.DeleteAsync(customerCreditCard);

        return deletedCustomerCreditCard;
    }
}
