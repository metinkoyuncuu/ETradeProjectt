using Application.Features.Cashbacks.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.Cashbacks.Rules;

public class CashbackBusinessRules : BaseBusinessRules
{
    private readonly ICashbackRepository _cashbackRepository;

    public CashbackBusinessRules(ICashbackRepository cashbackRepository)
    {
        _cashbackRepository = cashbackRepository;
    }

    public Task CashbackShouldExistWhenSelected(Cashback? cashback)
    {
        if (cashback == null)
            throw new BusinessException(CashbacksBusinessMessages.CashbackNotExists);
        return Task.CompletedTask;
    }

    public async Task CashbackIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        Cashback? cashback = await _cashbackRepository.GetAsync(
            predicate: c => c.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await CashbackShouldExistWhenSelected(cashback);
    }
}