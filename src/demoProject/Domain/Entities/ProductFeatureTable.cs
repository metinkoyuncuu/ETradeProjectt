using Core.Persistence.Repositories;

namespace Domain.Entities;

public class ProductFeatureTable : Entity<int>
{
    public string Column { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int ProductFeatureId { get; set; }
}
