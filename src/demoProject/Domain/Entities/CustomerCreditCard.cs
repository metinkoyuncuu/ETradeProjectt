using Core.Persistence.Repositories;

namespace Domain.Entities;

public class CustomerCreditCard : Entity<int>
{
    public int CustomerId { get; set; }
    public string CardType { get; set; } = string.Empty;
    public string HolderName { get; set; } = string.Empty;
    public string ExpireMonth { get; set; } = string.Empty;
    public string ExpireYear { get; set; } = string.Empty;
    public string CVV { get; set; } = string.Empty;
    public string CardNumber { get; set; } = string.Empty;
    public virtual Customer? Customer { get; set; }
}