using Core.Persistence.Repositories;

namespace Domain.Entities;

public class Cashback : Entity<int>
{
    public int OrderId { get; set; }
    public int CustomerId { get; set; }
    public float CashbackRatio { get; set; }
    public virtual Customer? Customer { get; set; }
    public virtual Order? Order { get; set; }
}

