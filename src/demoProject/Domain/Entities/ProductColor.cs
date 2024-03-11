using Core.Persistence.Repositories;

namespace Domain.Entities;

public class ProductColor : Entity<int>
{
    public int ProductId { get; set; }
    public int ColorId { get; set; }
    public virtual Product? Product { get; set; }
    public virtual Color? Color { get; set; }
}
