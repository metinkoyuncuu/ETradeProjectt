using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.CustomerCoupons;

public interface ICustomerCouponsService
{
    Task<CustomerCoupon?> GetAsync(
        Expression<Func<CustomerCoupon, bool>> predicate,
        Func<IQueryable<CustomerCoupon>, IIncludableQueryable<CustomerCoupon, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<CustomerCoupon>?> GetListAsync(
        Expression<Func<CustomerCoupon, bool>>? predicate = null,
        Func<IQueryable<CustomerCoupon>, IOrderedQueryable<CustomerCoupon>>? orderBy = null,
        Func<IQueryable<CustomerCoupon>, IIncludableQueryable<CustomerCoupon, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<CustomerCoupon> AddAsync(CustomerCoupon customerCoupon);
    Task<CustomerCoupon> UpdateAsync(CustomerCoupon customerCoupon);
    Task<CustomerCoupon> DeleteAsync(CustomerCoupon customerCoupon, bool permanent = false);
}
