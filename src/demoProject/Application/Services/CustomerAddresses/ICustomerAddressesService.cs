using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.CustomerAddresses;

public interface ICustomerAddressesService
{
    Task<CustomerAddress?> GetAsync(
        Expression<Func<CustomerAddress, bool>> predicate,
        Func<IQueryable<CustomerAddress>, IIncludableQueryable<CustomerAddress, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<CustomerAddress>?> GetListAsync(
        Expression<Func<CustomerAddress, bool>>? predicate = null,
        Func<IQueryable<CustomerAddress>, IOrderedQueryable<CustomerAddress>>? orderBy = null,
        Func<IQueryable<CustomerAddress>, IIncludableQueryable<CustomerAddress, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<CustomerAddress> AddAsync(CustomerAddress customerAddress);
    Task<CustomerAddress> UpdateAsync(CustomerAddress customerAddress);
    Task<CustomerAddress> DeleteAsync(CustomerAddress customerAddress, bool permanent = false);
}
