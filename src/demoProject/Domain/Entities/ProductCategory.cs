using Core.Persistence.Repositories;

namespace Domain.Entities;

public class ProductCategory : Entity<int>
{
    public int ProductId { get; set; }
    public int CategoryId { get; set; }
    public virtual Product? Product { get; set; }
    public virtual Category? Category { get; set; }
}
