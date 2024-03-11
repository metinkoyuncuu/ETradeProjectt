using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Shops;

public interface IShopsService
{
    Task<Shop?> GetAsync(
        Expression<Func<Shop, bool>> predicate,
        Func<IQueryable<Shop>, IIncludableQueryable<Shop, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Shop>?> GetListAsync(
        Expression<Func<Shop, bool>>? predicate = null,
        Func<IQueryable<Shop>, IOrderedQueryable<Shop>>? orderBy = null,
        Func<IQueryable<Shop>, IIncludableQueryable<Shop, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Shop> AddAsync(Shop shop);
    Task<Shop> UpdateAsync(Shop shop);
    Task<Shop> DeleteAsync(Shop shop, bool permanent = false);
}
