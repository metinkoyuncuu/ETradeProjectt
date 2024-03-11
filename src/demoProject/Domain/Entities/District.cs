using Core.Persistence.Repositories;

namespace Domain.Entities;

public class District : Entity<int>
{
    public string Name { get; set; } = string.Empty;
    public int CityId { get; set; }
    public virtual City? City { get; set; }
}

