using Application.Features.ReviewFeedbacks.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.ReviewFeedbacks;

public class ReviewFeedbacksManager : IReviewFeedbacksService
{
    private readonly IReviewFeedbackRepository _reviewFeedbackRepository;
    private readonly ReviewFeedbackBusinessRules _reviewFeedbackBusinessRules;

    public ReviewFeedbacksManager(IReviewFeedbackRepository reviewFeedbackRepository, ReviewFeedbackBusinessRules reviewFeedbackBusinessRules)
    {
        _reviewFeedbackRepository = reviewFeedbackRepository;
        _reviewFeedbackBusinessRules = reviewFeedbackBusinessRules;
    }

    public async Task<ReviewFeedback?> GetAsync(
        Expression<Func<ReviewFeedback, bool>> predicate,
        Func<IQueryable<ReviewFeedback>, IIncludableQueryable<ReviewFeedback, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        ReviewFeedback? reviewFeedback = await _reviewFeedbackRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return reviewFeedback;
    }

    public async Task<IPaginate<ReviewFeedback>?> GetListAsync(
        Expression<Func<ReviewFeedback, bool>>? predicate = null,
        Func<IQueryable<ReviewFeedback>, IOrderedQueryable<ReviewFeedback>>? orderBy = null,
        Func<IQueryable<ReviewFeedback>, IIncludableQueryable<ReviewFeedback, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<ReviewFeedback> reviewFeedbackList = await _reviewFeedbackRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return reviewFeedbackList;
    }

    public async Task<ReviewFeedback> AddAsync(ReviewFeedback reviewFeedback)
    {
        ReviewFeedback addedReviewFeedback = await _reviewFeedbackRepository.AddAsync(reviewFeedback);

        return addedReviewFeedback;
    }

    public async Task<ReviewFeedback> UpdateAsync(ReviewFeedback reviewFeedback)
    {
        ReviewFeedback updatedReviewFeedback = await _reviewFeedbackRepository.UpdateAsync(reviewFeedback);

        return updatedReviewFeedback;
    }

    public async Task<ReviewFeedback> DeleteAsync(ReviewFeedback reviewFeedback, bool permanent = false)
    {
        ReviewFeedback deletedReviewFeedback = await _reviewFeedbackRepository.DeleteAsync(reviewFeedback);

        return deletedReviewFeedback;
    }
}
