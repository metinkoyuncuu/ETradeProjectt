using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.Sellers;

public interface ISellersService
{
    Task<Seller?> GetAsync(
        Expression<Func<Seller, bool>> predicate,
        Func<IQueryable<Seller>, IIncludableQueryable<Seller, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<Seller>?> GetListAsync(
        Expression<Func<Seller, bool>>? predicate = null,
        Func<IQueryable<Seller>, IOrderedQueryable<Seller>>? orderBy = null,
        Func<IQueryable<Seller>, IIncludableQueryable<Seller, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<Seller> AddAsync(Seller seller);
    Task<Seller> UpdateAsync(Seller seller);
    Task<Seller> DeleteAsync(Seller seller, bool permanent = false);
}
