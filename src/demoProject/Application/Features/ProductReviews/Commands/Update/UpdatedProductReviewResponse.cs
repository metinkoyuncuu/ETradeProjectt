using Core.Application.Responses;

namespace Application.Features.ProductReviews.Commands.Update;

public class UpdatedProductReviewResponse : IResponse
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public int CustomerId { get; set; }
    public float Rate { get; set; }
    public string Comment { get; set; }
}