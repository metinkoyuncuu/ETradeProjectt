using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.CustomerOrders;

public interface ICustomerOrdersService
{
    Task<CustomerOrder?> GetAsync(
        Expression<Func<CustomerOrder, bool>> predicate,
        Func<IQueryable<CustomerOrder>, IIncludableQueryable<CustomerOrder, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<CustomerOrder>?> GetListAsync(
        Expression<Func<CustomerOrder, bool>>? predicate = null,
        Func<IQueryable<CustomerOrder>, IOrderedQueryable<CustomerOrder>>? orderBy = null,
        Func<IQueryable<CustomerOrder>, IIncludableQueryable<CustomerOrder, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<CustomerOrder> AddAsync(CustomerOrder customerOrder);
    Task<CustomerOrder> UpdateAsync(CustomerOrder customerOrder);
    Task<CustomerOrder> DeleteAsync(CustomerOrder customerOrder, bool permanent = false);
}
