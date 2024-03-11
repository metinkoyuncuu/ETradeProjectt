using Application.Features.ReviewImages.Rules;
using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Application.Services.ReviewImages;

public class ReviewImagesManager : IReviewImagesService
{
    private readonly IReviewImageRepository _reviewImageRepository;
    private readonly ReviewImageBusinessRules _reviewImageBusinessRules;

    public ReviewImagesManager(IReviewImageRepository reviewImageRepository, ReviewImageBusinessRules reviewImageBusinessRules)
    {
        _reviewImageRepository = reviewImageRepository;
        _reviewImageBusinessRules = reviewImageBusinessRules;
    }

    public async Task<ReviewImage?> GetAsync(
        Expression<Func<ReviewImage, bool>> predicate,
        Func<IQueryable<ReviewImage>, IIncludableQueryable<ReviewImage, object>>? include = null,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        ReviewImage? reviewImage = await _reviewImageRepository.GetAsync(predicate, include, withDeleted, enableTracking, cancellationToken);
        return reviewImage;
    }

    public async Task<IPaginate<ReviewImage>?> GetListAsync(
        Expression<Func<ReviewImage, bool>>? predicate = null,
        Func<IQueryable<ReviewImage>, IOrderedQueryable<ReviewImage>>? orderBy = null,
        Func<IQueryable<ReviewImage>, IIncludableQueryable<ReviewImage, object>>? include = null,
        int index = 0,
        int size = 10,
        bool withDeleted = false,
        bool enableTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        IPaginate<ReviewImage> reviewImageList = await _reviewImageRepository.GetListAsync(
            predicate,
            orderBy,
            include,
            index,
            size,
            withDeleted,
            enableTracking,
            cancellationToken
        );
        return reviewImageList;
    }

    public async Task<ReviewImage> AddAsync(ReviewImage reviewImage)
    {
        ReviewImage addedReviewImage = await _reviewImageRepository.AddAsync(reviewImage);

        return addedReviewImage;
    }

    public async Task<ReviewImage> UpdateAsync(ReviewImage reviewImage)
    {
        ReviewImage updatedReviewImage = await _reviewImageRepository.UpdateAsync(reviewImage);

        return updatedReviewImage;
    }

    public async Task<ReviewImage> DeleteAsync(ReviewImage reviewImage, bool permanent = false)
    {
        ReviewImage deletedReviewImage = await _reviewImageRepository.DeleteAsync(reviewImage);

        return deletedReviewImage;
    }
}
