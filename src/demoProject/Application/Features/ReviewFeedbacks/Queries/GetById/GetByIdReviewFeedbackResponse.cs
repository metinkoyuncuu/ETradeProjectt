using Core.Application.Responses;

namespace Application.Features.ReviewFeedbacks.Queries.GetById;

public class GetByIdReviewFeedbackResponse : IResponse
{
    public int Id { get; set; }
    public int ProductReviewId { get; set; }
    public int CustomerId { get; set; }
    public bool Feedback { get; set; }
}