using Core.Application.Responses;

namespace Application.Features.ReviewImages.Commands.Update;

public class UpdatedReviewImageResponse : IResponse
{
    public int Id { get; set; }
    public int ProductReviewId { get; set; }
    public int ImageId { get; set; }
}