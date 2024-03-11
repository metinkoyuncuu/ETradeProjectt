using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.OrderProducts;

public interface IOrderProductsService
{
    Task<OrderProduct?> GetAsync(
        Expression<Func<OrderProduct, bool>> predicate,
        Func<IQueryable<OrderProduct>, IIncludableQueryable<OrderProduct, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<OrderProduct>?> GetListAsync(
        Expression<Func<OrderProduct, bool>>? predicate = null,
        Func<IQueryable<OrderProduct>, IOrderedQueryable<OrderProduct>>? orderBy = null,
        Func<IQueryable<OrderProduct>, IIncludableQueryable<OrderProduct, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<OrderProduct> AddAsync(OrderProduct orderProduct);
    Task<OrderProduct> UpdateAsync(OrderProduct orderProduct);
    Task<OrderProduct> DeleteAsync(OrderProduct orderProduct, bool permanent = false);
}
