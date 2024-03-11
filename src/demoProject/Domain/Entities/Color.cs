using Core.Persistence.Repositories;

namespace Domain.Entities;

public class Color : Entity<int>
{
    public string Name { get; set; } = string.Empty;
    public bool IsVerified { get; set; }
}

