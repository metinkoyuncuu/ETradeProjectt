using Core.Persistence.Repositories;

namespace Domain.Entities;

public class Shop : Entity<int>
{
    public string Name { get; set; } = string.Empty;
    public string? TaxNumber { get; set; }
    public string AccessKey { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public bool IsVerified { get; set; }
    public float Balance { get; set; }
    public virtual ICollection<ShopImage>? ShopImages { get; set; }
    public virtual ICollection<ShopProduct>? ShopProducts { get; set; }
    public virtual ICollection<ShopSeller>? ShopSellers { get; set; }
}
