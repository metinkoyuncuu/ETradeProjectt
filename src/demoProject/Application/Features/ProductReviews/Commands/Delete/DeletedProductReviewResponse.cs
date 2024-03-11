using Core.Application.Responses;

namespace Application.Features.ProductReviews.Commands.Delete;

public class DeletedProductReviewResponse : IResponse
{
    public int Id { get; set; }
}