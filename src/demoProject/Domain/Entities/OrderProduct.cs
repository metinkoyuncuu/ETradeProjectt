using Core.Persistence.Repositories;

namespace Domain.Entities;

public class OrderProduct:Entity<int>
{
    public int OrderId { get; set; }
    public int ProductId { get; set; }
    public virtual Order? Order { get; set; }
    public virtual Product? Product { get; set; }
}

