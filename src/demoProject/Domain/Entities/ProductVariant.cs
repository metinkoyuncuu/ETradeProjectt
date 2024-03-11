using Core.Persistence.Repositories;

namespace Domain.Entities;

public class ProductVariant : Entity<int>
{
    public int ProductId { get; set; }
    public int ColorId { get; set; }
    public int QuantityInStock { get; set; }
    public int SizeId { get; set; }
    public virtual Size? Size { get; set; }
    public virtual Product? Product { get; set; }
    public virtual Color? Color { get; set; }
}
