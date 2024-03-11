using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.CustomerWishes;

public interface ICustomerWishesService
{
    Task<CustomerWish?> GetAsync(
        Expression<Func<CustomerWish, bool>> predicate,
        Func<IQueryable<CustomerWish>, IIncludableQueryable<CustomerWish, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<CustomerWish>?> GetListAsync(
        Expression<Func<CustomerWish, bool>>? predicate = null,
        Func<IQueryable<CustomerWish>, IOrderedQueryable<CustomerWish>>? orderBy = null,
        Func<IQueryable<CustomerWish>, IIncludableQueryable<CustomerWish, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<CustomerWish> AddAsync(CustomerWish customerWish);
    Task<CustomerWish> UpdateAsync(CustomerWish customerWish);
    Task<CustomerWish> DeleteAsync(CustomerWish customerWish, bool permanent = false);
}
