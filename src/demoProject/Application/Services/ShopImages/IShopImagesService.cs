using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.ShopImages;

public interface IShopImagesService
{
    Task<ShopImage?> GetAsync(
        Expression<Func<ShopImage, bool>> predicate,
        Func<IQueryable<ShopImage>, IIncludableQueryable<ShopImage, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<ShopImage>?> GetListAsync(
        Expression<Func<ShopImage, bool>>? predicate = null,
        Func<IQueryable<ShopImage>, IOrderedQueryable<ShopImage>>? orderBy = null,
        Func<IQueryable<ShopImage>, IIncludableQueryable<ShopImage, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<ShopImage> AddAsync(ShopImage shopImage);
    Task<ShopImage> UpdateAsync(ShopImage shopImage);
    Task<ShopImage> DeleteAsync(ShopImage shopImage, bool permanent = false);
}
