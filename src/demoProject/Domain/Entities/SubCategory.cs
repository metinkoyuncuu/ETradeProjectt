using Core.Persistence.Repositories;

namespace Domain.Entities;

public class SubCategory : Entity<int>
{
    public string Name { get; set; } = string.Empty;
    public int CategoryId { get; set; }
    public bool IsVerified { get; set; }
}



