using Core.Persistence.Repositories;

namespace Domain.Entities;

public class ReviewFeedback:Entity<int>
{
    public int ProductReviewId { get; set; }
    public int CustomerId { get; set; }
    public bool Feedback { get; set; }
    public virtual ProductReview? ProductReview { get; set; }
    public virtual Customer? Customer { get; set; }
}