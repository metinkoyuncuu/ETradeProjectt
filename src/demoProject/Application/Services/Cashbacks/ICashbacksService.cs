using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Cashbacks;

public interface ICashbacksService
{
    Task<Cashback?> GetAsync(
        Expression<Func<Cashback, bool>> predicate,
        Func<IQueryable<Cashback>, IIncludableQueryable<Cashback, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Cashback>?> GetListAsync(
        Expression<Func<Cashback, bool>>? predicate = null,
        Func<IQueryable<Cashback>, IOrderedQueryable<Cashback>>? orderBy = null,
        Func<IQueryable<Cashback>, IIncludableQueryable<Cashback, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Cashback> AddAsync(Cashback cashback);
    Task<Cashback> UpdateAsync(Cashback cashback);
    Task<Cashback> DeleteAsync(Cashback cashback, bool permanent = false);
}
