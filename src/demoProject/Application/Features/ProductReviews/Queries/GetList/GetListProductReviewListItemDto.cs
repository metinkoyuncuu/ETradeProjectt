using Core.Application.Dtos;

namespace Application.Features.ProductReviews.Queries.GetList;

public class GetListProductReviewListItemDto : IDto
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public int CustomerId { get; set; }
    public float Rate { get; set; }
    public string Comment { get; set; }
}