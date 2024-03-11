using Application.Features.ReviewFeedbacks.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.ReviewFeedbacks.Rules;

public class ReviewFeedbackBusinessRules : BaseBusinessRules
{
    private readonly IReviewFeedbackRepository _reviewFeedbackRepository;

    public ReviewFeedbackBusinessRules(IReviewFeedbackRepository reviewFeedbackRepository)
    {
        _reviewFeedbackRepository = reviewFeedbackRepository;
    }

    public Task ReviewFeedbackShouldExistWhenSelected(ReviewFeedback? reviewFeedback)
    {
        if (reviewFeedback == null)
            throw new BusinessException(ReviewFeedbacksBusinessMessages.ReviewFeedbackNotExists);
        return Task.CompletedTask;
    }

    public async Task ReviewFeedbackIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        ReviewFeedback? reviewFeedback = await _reviewFeedbackRepository.GetAsync(
            predicate: rf => rf.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await ReviewFeedbackShouldExistWhenSelected(reviewFeedback);
    }
}