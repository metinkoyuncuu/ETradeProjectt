using Application.Features.TermConditions.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.TermConditions.Rules;

public class TermConditionBusinessRules : BaseBusinessRules
{
    private readonly ITermConditionRepository _termConditionRepository;

    public TermConditionBusinessRules(ITermConditionRepository termConditionRepository)
    {
        _termConditionRepository = termConditionRepository;
    }

    public Task TermConditionShouldExistWhenSelected(TermCondition? termCondition)
    {
        if (termCondition == null)
            throw new BusinessException(TermConditionsBusinessMessages.TermConditionNotExists);
        return Task.CompletedTask;
    }

    public async Task TermConditionIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        TermCondition? termCondition = await _termConditionRepository.GetAsync(
            predicate: tc => tc.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await TermConditionShouldExistWhenSelected(termCondition);
    }
}