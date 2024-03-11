using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Coupons;

public interface ICouponsService
{
    Task<Coupon?> GetAsync(
        Expression<Func<Coupon, bool>> predicate,
        Func<IQueryable<Coupon>, IIncludableQueryable<Coupon, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Coupon>?> GetListAsync(
        Expression<Func<Coupon, bool>>? predicate = null,
        Func<IQueryable<Coupon>, IOrderedQueryable<Coupon>>? orderBy = null,
        Func<IQueryable<Coupon>, IIncludableQueryable<Coupon, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Coupon> AddAsync(Coupon coupon);
    Task<Coupon> UpdateAsync(Coupon coupon);
    Task<Coupon> DeleteAsync(Coupon coupon, bool permanent = false);
}
