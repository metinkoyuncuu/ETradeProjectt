using Core.Application.Responses;

namespace Application.Features.ReviewImages.Queries.GetById;

public class GetByIdReviewImageResponse : IResponse
{
    public int Id { get; set; }
    public int ProductReviewId { get; set; }
    public int ImageId { get; set; }
}