using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Bills;

public interface IBillsService
{
    Task<Bill?> GetAsync(
        Expression<Func<Bill, bool>> predicate,
        Func<IQueryable<Bill>, IIncludableQueryable<Bill, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Bill>?> GetListAsync(
        Expression<Func<Bill, bool>>? predicate = null,
        Func<IQueryable<Bill>, IOrderedQueryable<Bill>>? orderBy = null,
        Func<IQueryable<Bill>, IIncludableQueryable<Bill, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Bill> AddAsync(Bill bill);
    Task<Bill> UpdateAsync(Bill bill);
    Task<Bill> DeleteAsync(Bill bill, bool permanent = false);
}
