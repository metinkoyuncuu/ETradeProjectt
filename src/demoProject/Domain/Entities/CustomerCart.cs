using Core.Persistence.Repositories;

namespace Domain.Entities;

public class CustomerCart : Entity<int>
{
    public int CustomerId { get; set; }
    public int ProductId { get; set; }
    public int CartId { get; set; }
    public bool IsSelected { get; set; }
    public virtual Customer? Customer { get; set; }
    public virtual Product? Product { get; set; }
    public virtual Cart? Cart { get; set; }
}
