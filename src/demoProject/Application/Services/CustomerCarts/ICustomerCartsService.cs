using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.CustomerCarts;

public interface ICustomerCartsService
{
    Task<CustomerCart?> GetAsync(
        Expression<Func<CustomerCart, bool>> predicate,
        Func<IQueryable<CustomerCart>, IIncludableQueryable<CustomerCart, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<CustomerCart>?> GetListAsync(
        Expression<Func<CustomerCart, bool>>? predicate = null,
        Func<IQueryable<CustomerCart>, IOrderedQueryable<CustomerCart>>? orderBy = null,
        Func<IQueryable<CustomerCart>, IIncludableQueryable<CustomerCart, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<CustomerCart> AddAsync(CustomerCart customerCart);
    Task<CustomerCart> UpdateAsync(CustomerCart customerCart);
    Task<CustomerCart> DeleteAsync(CustomerCart customerCart, bool permanent = false);
}
