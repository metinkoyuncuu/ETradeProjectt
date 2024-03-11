using Core.Application.Responses;

namespace Application.Features.ReviewFeedbacks.Commands.Delete;

public class DeletedReviewFeedbackResponse : IResponse
{
    public int Id { get; set; }
}