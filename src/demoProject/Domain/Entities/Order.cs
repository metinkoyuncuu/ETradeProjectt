using Core.Persistence.Repositories;

namespace Domain.Entities;
public class Order:Entity<int>
{
    public float TotalPrice { get; set; }
    public string OrderStatus { get; set; } = string.Empty;
    public string PaymentMethod { get; set; } = string.Empty;
    public int ShopId { get; set; }
    public int? CustomerId { get; set; }
    public int? CartId { get; set; }
    public virtual ICollection<OrderProduct>? OrderProducts { get; set; }
    public virtual Customer? Customer { get; set; }
    public virtual Shop? Shop { get; set; }
    public virtual Cart? Cart { get; set; }
}

