using Core.Persistence.Repositories;

namespace Domain.Entities;

public class ShopSeller:Entity<int>
{
    public int ShopId { get; set; }
    public int SellerId { get; set; }
    public virtual Shop? Shop { get; set; }
    public virtual Seller? Seller { get; set; }
}