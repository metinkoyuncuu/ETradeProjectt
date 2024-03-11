using Core.Application.Responses;

namespace Application.Features.ReviewImages.Commands.Create;

public class CreatedReviewImageResponse : IResponse
{
    public int Id { get; set; }
    public int ProductReviewId { get; set; }
    public int ImageId { get; set; }
}