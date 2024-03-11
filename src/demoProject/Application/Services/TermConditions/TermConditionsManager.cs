using Application.Features.TermConditions.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.TermConditions;

public class TermConditionsManager : ITermConditionsService
{
    private readonly ITermConditionRepository _termConditionRepository;
    private readonly TermConditionBusinessRules _termConditionBusinessRules;

    public TermConditionsManager(ITermConditionRepository termConditionRepository, TermConditionBusinessRules termConditionBusinessRules)
    {
        _termConditionRepository = termConditionRepository;
        _termConditionBusinessRules = termConditionBusinessRules;
    }

    public async Task<TermCondition?> GetAsync(
        Expression<Func<TermCondition, bool>> predicate,
        Func<IQueryable<TermCondition>, IIncludableQueryable<TermCondition, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        TermCondition? termCondition = await _termConditionRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return termCondition;
    }

    public async Task<IPaginate<TermCondition>?> GetListAsync(
        Expression<Func<TermCondition, bool>>? predicate = null,
        Func<IQueryable<TermCondition>, IOrderedQueryable<TermCondition>>? orderBy = null,
        Func<IQueryable<TermCondition>, IIncludableQueryable<TermCondition, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<TermCondition> termConditionList = await _termConditionRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return termConditionList;
    }

    public async Task<TermCondition> AddAsync(TermCondition termCondition)
    {
        TermCondition addedTermCondition = await _termConditionRepository.AddAsync(termCondition);

        return addedTermCondition;
    }

    public async Task<TermCondition> UpdateAsync(TermCondition termCondition)
    {
        TermCondition updatedTermCondition = await _termConditionRepository.UpdateAsync(termCondition);

        return updatedTermCondition;
    }

    public async Task<TermCondition> DeleteAsync(TermCondition termCondition, bool permanent = false)
    {
        TermCondition deletedTermCondition = await _termConditionRepository.DeleteAsync(termCondition);

        return deletedTermCondition;
    }
}
