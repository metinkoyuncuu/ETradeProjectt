using Core.Application.Responses;

namespace Application.Features.ReviewImages.Commands.Delete;

public class DeletedReviewImageResponse : IResponse
{
    public int Id { get; set; }
}