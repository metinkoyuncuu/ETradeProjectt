using Application.Features.Bills.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.Bills.Rules;

public class BillBusinessRules : BaseBusinessRules
{
    private readonly IBillRepository _billRepository;

    public BillBusinessRules(IBillRepository billRepository)
    {
        _billRepository = billRepository;
    }

    public Task BillShouldExistWhenSelected(Bill? bill)
    {
        if (bill == null)
            throw new BusinessException(BillsBusinessMessages.BillNotExists);
        return Task.CompletedTask;
    }

    public async Task BillIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        Bill? bill = await _billRepository.GetAsync(
            predicate: b => b.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await BillShouldExistWhenSelected(bill);
    }
}