using Core.Persistence.Repositories;

namespace Domain.Entities;

public class Gender : Entity<int>
{
    public string Name { get; set; } = string.Empty;
}

