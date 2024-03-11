using Core.Application.Responses;

namespace Application.Features.ReviewFeedbacks.Commands.Create;

public class CreatedReviewFeedbackResponse : IResponse
{
    public int Id { get; set; }
    public int ProductReviewId { get; set; }
    public int CustomerId { get; set; }
    public bool Feedback { get; set; }
}