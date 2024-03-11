using Application.Features.CustomerCompares.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.CustomerCompares.Rules;

public class CustomerCompareBusinessRules : BaseBusinessRules
{
    private readonly ICustomerCompareRepository _customerCompareRepository;

    public CustomerCompareBusinessRules(ICustomerCompareRepository customerCompareRepository)
    {
        _customerCompareRepository = customerCompareRepository;
    }

    public Task CustomerCompareShouldExistWhenSelected(CustomerCompare? customerCompare)
    {
        if (customerCompare == null)
            throw new BusinessException(CustomerComparesBusinessMessages.CustomerCompareNotExists);
        return Task.CompletedTask;
    }

    public async Task CustomerCompareIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        CustomerCompare? customerCompare = await _customerCompareRepository.GetAsync(
            predicate: cc => cc.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await CustomerCompareShouldExistWhenSelected(customerCompare);
    }
}