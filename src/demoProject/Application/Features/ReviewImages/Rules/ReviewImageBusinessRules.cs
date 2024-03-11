using Application.Features.ReviewImages.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.ReviewImages.Rules;

public class ReviewImageBusinessRules : BaseBusinessRules
{
    private readonly IReviewImageRepository _reviewImageRepository;

    public ReviewImageBusinessRules(IReviewImageRepository reviewImageRepository)
    {
        _reviewImageRepository = reviewImageRepository;
    }

    public Task ReviewImageShouldExistWhenSelected(ReviewImage? reviewImage)
    {
        if (reviewImage == null)
            throw new BusinessException(ReviewImagesBusinessMessages.ReviewImageNotExists);
        return Task.CompletedTask;
    }

    public async Task ReviewImageIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        ReviewImage? reviewImage = await _reviewImageRepository.GetAsync(
            predicate: ri => ri.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await ReviewImageShouldExistWhenSelected(reviewImage);
    }
}