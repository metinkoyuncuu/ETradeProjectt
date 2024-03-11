using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.ReviewFeedbacks;

public interface IReviewFeedbacksService
{
    Task<ReviewFeedback?> GetAsync(
        Expression<Func<ReviewFeedback, bool>> predicate,
        Func<IQueryable<ReviewFeedback>, IIncludableQueryable<ReviewFeedback, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<IPaginate<ReviewFeedback>?> GetListAsync(
        Expression<Func<ReviewFeedback, bool>>? predicate = null,
        Func<IQueryable<ReviewFeedback>, IOrderedQueryable<ReviewFeedback>>? orderBy = null,
        Func<IQueryable<ReviewFeedback>, IIncludableQueryable<ReviewFeedback, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    );
    Task<ReviewFeedback> AddAsync(ReviewFeedback reviewFeedback);
    Task<ReviewFeedback> UpdateAsync(ReviewFeedback reviewFeedback);
    Task<ReviewFeedback> DeleteAsync(ReviewFeedback reviewFeedback, bool permanent = false);
}
