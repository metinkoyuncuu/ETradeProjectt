using Core.Persistence.Repositories;

namespace Domain.Entities;

public class ProductReview : Entity<int>
{
    public int ProductId { get; set; }
    public int CustomerId { get; set; }
    public float Rate { get; set; }
    public string Comment { get; set; } = string.Empty;
    public virtual ICollection<ReviewImage>? ReviewImages { get; set; }
    public virtual ICollection<ReviewFeedback>? ReviewFeedbacks { get; set; }
}
