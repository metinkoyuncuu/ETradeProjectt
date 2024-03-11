using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Shippings;

public interface IShippingsService
{
    Task<Shipping?> GetAsync(
        Expression<Func<Shipping, bool>> predicate,
        Func<IQueryable<Shipping>, IIncludableQueryable<Shipping, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Shipping>?> GetListAsync(
        Expression<Func<Shipping, bool>>? predicate = null,
        Func<IQueryable<Shipping>, IOrderedQueryable<Shipping>>? orderBy = null,
        Func<IQueryable<Shipping>, IIncludableQueryable<Shipping, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Shipping> AddAsync(Shipping shipping);
    Task<Shipping> UpdateAsync(Shipping shipping);
    Task<Shipping> DeleteAsync(Shipping shipping, bool permanent = false);
}
