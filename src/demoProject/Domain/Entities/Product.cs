using Core.Persistence.Repositories;

namespace Domain.Entities;

public class Product : Entity<int>
{
    public string SKU { get; set; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public float Price { get; set; }
    public bool IsDiscounted { get; set; }
    public string DiscountType { get; set; } = string.Empty;
    public string DiscountValue { get; set; } = string.Empty;
    public string? Weight { get; set; }
    public int QuantityInStock { get; set; }
    public int SubCategoryId { get; set; }
    public float ShipPrice { get; set; }
    public int BrandId { get; set; }
    public virtual Brand? Brand { get; set; }
    public virtual SubCategory? SubCategory { get; set; }
    public virtual ICollection<ProductSize>? ProductSizes { get; set; }
    public virtual ICollection<ProductColor>? ProductColors { get; set; }
    public virtual ICollection<ProductImage>? ProductImages { get; set; }
    public virtual ICollection<ProductTag>? ProductTags { get; set; }
    public virtual ICollection<ProductCategory>? ProductCategories { get; set; }
    public virtual ICollection<ProductReview>? ProductReviews { get; set; }
    public virtual ICollection<ProductQuestion>? ProductQuestions { get; set; }
    public virtual ICollection<ProductVariant>? ProductVariants { get; set; }
    public virtual ICollection<ShopProduct>? ShopProducts { get; set; }
    public virtual ICollection<ProductFeature>? ProductFeatures { get; set; }
}
