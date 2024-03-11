using Core.Persistence.Repositories;

namespace Domain.Entities;

public class ProductQuestion : Entity<int>
{
    public int ProductId { get; set; }
    public int CustomerId { get; set; }
    public int SellerId { get; set; }
    public string Question { get; set; } = string.Empty;
    public string Answer { get; set; } = string.Empty;
    public virtual Seller? Seller { get; set; }

}
