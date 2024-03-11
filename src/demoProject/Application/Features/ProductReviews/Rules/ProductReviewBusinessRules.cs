using Application.Features.ProductReviews.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.ProductReviews.Rules;

public class ProductReviewBusinessRules : BaseBusinessRules
{
    private readonly IProductReviewRepository _productReviewRepository;

    public ProductReviewBusinessRules(IProductReviewRepository productReviewRepository)
    {
        _productReviewRepository = productReviewRepository;
    }

    public Task ProductReviewShouldExistWhenSelected(ProductReview? productReview)
    {
        if (productReview == null)
            throw new BusinessException(ProductReviewsBusinessMessages.ProductReviewNotExists);
        return Task.CompletedTask;
    }

    public async Task ProductReviewIdShouldExistWhenSelected(int id, CancellationToken cancellationToken)
    {
        ProductReview? productReview = await _productReviewRepository.GetAsync(
            predicate: pr => pr.Id == id,
            enableTracking: false,
            cancellationToken: cancellationToken
        );
        await ProductReviewShouldExistWhenSelected(productReview);
    }
}