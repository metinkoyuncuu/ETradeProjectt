using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Sizes;

public interface ISizesService
{
    Task<Size?> GetAsync(
        Expression<Func<Size, bool>> predicate,
        Func<IQueryable<Size>, IIncludableQueryable<Size, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Size>?> GetListAsync(
        Expression<Func<Size, bool>>? predicate = null,
        Func<IQueryable<Size>, IOrderedQueryable<Size>>? orderBy = null,
        Func<IQueryable<Size>, IIncludableQueryable<Size, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Size> AddAsync(Size size);
    Task<Size> UpdateAsync(Size size);
    Task<Size> DeleteAsync(Size size, bool permanent = false);
}
