using Core.Persistence.Repositories;

namespace Domain.Entities;

public class CustomerWish : Entity<int>
{
    public int CustomerId { get; set; }
    public int ProductId { get; set; }
    public virtual Customer? Customer { get; set; }
    public virtual Product? Product { get; set; }
}
