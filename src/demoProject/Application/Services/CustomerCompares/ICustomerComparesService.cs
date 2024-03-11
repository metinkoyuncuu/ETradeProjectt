using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.CustomerCompares;

public interface ICustomerComparesService
{
    Task<CustomerCompare?> GetAsync(
        Expression<Func<CustomerCompare, bool>> predicate,
        Func<IQueryable<CustomerCompare>, IIncludableQueryable<CustomerCompare, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<CustomerCompare>?> GetListAsync(
        Expression<Func<CustomerCompare, bool>>? predicate = null,
        Func<IQueryable<CustomerCompare>, IOrderedQueryable<CustomerCompare>>? orderBy = null,
        Func<IQueryable<CustomerCompare>, IIncludableQueryable<CustomerCompare, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<CustomerCompare> AddAsync(CustomerCompare customerCompare);
    Task<CustomerCompare> UpdateAsync(CustomerCompare customerCompare);
    Task<CustomerCompare> DeleteAsync(CustomerCompare customerCompare, bool permanent = false);
}
