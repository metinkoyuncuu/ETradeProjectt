using Core.Persistence.Repositories;

namespace Domain.Entities;

public class ProductFeature:Entity<int>
{
    public int ProductId { get; set; }
    public string Header { get; set; } = string.Empty;
    public virtual ICollection<ProductFeatureTable>? ProductFeatureTables { get; set; }

}
