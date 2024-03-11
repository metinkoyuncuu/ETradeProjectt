using Application.Features.Cashbacks.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Cashbacks;

public class CashbacksManager : ICashbacksService
{
    private readonly ICashbackRepository _cashbackRepository;
    private readonly CashbackBusinessRules _cashbackBusinessRules;

    public CashbacksManager(ICashbackRepository cashbackRepository, CashbackBusinessRules cashbackBusinessRules)
    {
        _cashbackRepository = cashbackRepository;
        _cashbackBusinessRules = cashbackBusinessRules;
    }

    public async Task<Cashback?> GetAsync(
        Expression<Func<Cashback, bool>> predicate,
        Func<IQueryable<Cashback>, IIncludableQueryable<Cashback, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        Cashback? cashback = await _cashbackRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return cashback;
    }

    public async Task<IPaginate<Cashback>?> GetListAsync(
        Expression<Func<Cashback, bool>>? predicate = null,
        Func<IQueryable<Cashback>, IOrderedQueryable<Cashback>>? orderBy = null,
        Func<IQueryable<Cashback>, IIncludableQueryable<Cashback, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<Cashback> cashbackList = await _cashbackRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return cashbackList;
    }

    public async Task<Cashback> AddAsync(Cashback cashback)
    {
        Cashback addedCashback = await _cashbackRepository.AddAsync(cashback);

        return addedCashback;
    }

    public async Task<Cashback> UpdateAsync(Cashback cashback)
    {
        Cashback updatedCashback = await _cashbackRepository.UpdateAsync(cashback);

        return updatedCashback;
    }

    public async Task<Cashback> DeleteAsync(Cashback cashback, bool permanent = false)
    {
        Cashback deletedCashback = await _cashbackRepository.DeleteAsync(cashback);

        return deletedCashback;
    }
}
