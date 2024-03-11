using Core.Persistence.Repositories;

namespace Domain.Entities;

public class City : Entity<int>
{
    public string Name { get; set; } = string.Empty;
}

