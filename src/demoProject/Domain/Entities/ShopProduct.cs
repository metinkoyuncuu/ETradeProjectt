using Core.Persistence.Repositories;

namespace Domain.Entities;

public class ShopProduct : Entity<int>
{
    public int ProductId { get; set; }
    public int ShopId { get; set; }
    public virtual Product? Product { get; set; }
    public virtual Shop? Shop { get; set; }
}
