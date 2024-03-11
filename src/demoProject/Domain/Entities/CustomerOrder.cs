using Core.Persistence.Repositories;

namespace Domain.Entities;

public class CustomerOrder : Entity<int>
{
    public int CustomerId { get; set; }
    public int OrderId { get; set; }
    public virtual Customer? Customer { get; set; }
    public virtual Order? Order { get; set; }
}
