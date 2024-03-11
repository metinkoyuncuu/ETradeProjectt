using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.TermConditions;

public interface ITermConditionsService
{
    Task<TermCondition?> GetAsync(
        Expression<Func<TermCondition, bool>> predicate,
        Func<IQueryable<TermCondition>, IIncludableQueryable<TermCondition, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<TermCondition>?> GetListAsync(
        Expression<Func<TermCondition, bool>>? predicate = null,
        Func<IQueryable<TermCondition>, IOrderedQueryable<TermCondition>>? orderBy = null,
        Func<IQueryable<TermCondition>, IIncludableQueryable<TermCondition, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<TermCondition> AddAsync(TermCondition termCondition);
    Task<TermCondition> UpdateAsync(TermCondition termCondition);
    Task<TermCondition> DeleteAsync(TermCondition termCondition, bool permanent = false);
}
