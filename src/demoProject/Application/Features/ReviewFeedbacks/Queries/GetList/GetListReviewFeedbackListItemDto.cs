using Core.Application.Dtos;

namespace Application.Features.ReviewFeedbacks.Queries.GetList;

public class GetListReviewFeedbackListItemDto : IDto
{
    public int Id { get; set; }
    public int ProductReviewId { get; set; }
    public int CustomerId { get; set; }
    public bool Feedback { get; set; }
}