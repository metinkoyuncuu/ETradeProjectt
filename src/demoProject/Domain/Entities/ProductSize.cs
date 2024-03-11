using Core.Persistence.Repositories;

namespace Domain.Entities;

public class ProductSize : Entity<int>
{
    public int ProductId { get; set; }
    public int SizeId { get; set; }
    public virtual Product? Product { get; set; }
    public virtual Size? Size { get; set; } 
}
