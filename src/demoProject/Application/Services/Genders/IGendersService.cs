using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Genders;

public interface IGendersService
{
    Task<Gender?> GetAsync(
        Expression<Func<Gender, bool>> predicate,
        Func<IQueryable<Gender>, IIncludableQueryable<Gender, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Gender>?> GetListAsync(
        Expression<Func<Gender, bool>>? predicate = null,
        Func<IQueryable<Gender>, IOrderedQueryable<Gender>>? orderBy = null,
        Func<IQueryable<Gender>, IIncludableQueryable<Gender, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Gender> AddAsync(Gender gender);
    Task<Gender> UpdateAsync(Gender gender);
    Task<Gender> DeleteAsync(Gender gender, bool permanent = false);
}
