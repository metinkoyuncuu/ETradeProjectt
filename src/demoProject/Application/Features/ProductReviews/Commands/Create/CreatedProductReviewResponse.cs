using Core.Application.Responses;

namespace Application.Features.ProductReviews.Commands.Create;

public class CreatedProductReviewResponse : IResponse
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public int CustomerId { get; set; }
    public float Rate { get; set; }
    public string Comment { get; set; }
}