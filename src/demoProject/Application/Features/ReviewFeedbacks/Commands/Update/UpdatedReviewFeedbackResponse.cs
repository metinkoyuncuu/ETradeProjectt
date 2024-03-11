using Core.Application.Responses;

namespace Application.Features.ReviewFeedbacks.Commands.Update;

public class UpdatedReviewFeedbackResponse : IResponse
{
    public int Id { get; set; }
    public int ProductReviewId { get; set; }
    public int CustomerId { get; set; }
    public bool Feedback { get; set; }
}