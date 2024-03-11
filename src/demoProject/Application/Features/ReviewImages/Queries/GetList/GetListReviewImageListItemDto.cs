using Core.Application.Dtos;

namespace Application.Features.ReviewImages.Queries.GetList;

public class GetListReviewImageListItemDto : IDto
{
    public int Id { get; set; }
    public int ProductReviewId { get; set; }
    public int ImageId { get; set; }
}