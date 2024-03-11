using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.ReviewImages;

public interface IReviewImagesService
{
    Task<ReviewImage?> GetAsync(
        Expression<Func<ReviewImage, bool>> predicate,
        Func<IQueryable<ReviewImage>, IIncludableQueryable<ReviewImage, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<ReviewImage>?> GetListAsync(
        Expression<Func<ReviewImage, bool>>? predicate = null,
        Func<IQueryable<ReviewImage>, IOrderedQueryable<ReviewImage>>? orderBy = null,
        Func<IQueryable<ReviewImage>, IIncludableQueryable<ReviewImage, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<ReviewImage> AddAsync(ReviewImage reviewImage);
    Task<ReviewImage> UpdateAsync(ReviewImage reviewImage);
    Task<ReviewImage> DeleteAsync(ReviewImage reviewImage, bool permanent = false);
}
