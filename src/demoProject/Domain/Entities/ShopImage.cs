using Core.Persistence.Repositories;

namespace Domain.Entities;

public class ShopImage : Entity<int>
{
    public int ShopId { get; set; }
    public int ImageId { get; set; }
    public string ImageType { get; set; } = string.Empty;
    public virtual Shop? Shop { get; set; }
    public virtual Image? Image { get; set; }
}
