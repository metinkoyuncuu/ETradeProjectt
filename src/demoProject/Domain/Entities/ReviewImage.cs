using Core.Persistence.Repositories;

namespace Domain.Entities;

public class ReviewImage : Entity<int>
{
    public int ProductReviewId { get; set; }
    public int ImageId { get; set; }
    public virtual ProductReview? ProductReview { get; set; }
    public virtual Image? Image { get; set; }
}