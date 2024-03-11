using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products").HasKey(p => p.Id);

        builder.Property(p => p.Id).HasColumnName("Id").IsRequired();
        builder.Property(p => p.SKU).HasColumnName("SKU");
        builder.Property(p => p.Title).HasColumnName("Title");
        builder.Property(p => p.Description).HasColumnName("Description");
        builder.Property(p => p.Price).HasColumnName("Price");
        builder.Property(p => p.IsDiscounted).HasColumnName("IsDiscounted");
        builder.Property(p => p.DiscountType).HasColumnName("DiscountType");
        builder.Property(p => p.DiscountValue).HasColumnName("DiscountValue");
        builder.Property(p => p.Weight).HasColumnName("Weight");
        builder.Property(p => p.QuantityInStock).HasColumnName("QuantityInStock");
        builder.Property(p => p.SubCategoryId).HasColumnName("SubCategoryId");
        builder.Property(p => p.ShipPrice).HasColumnName("ShipPrice");
        builder.Property(p => p.BrandId).HasColumnName("BrandId");
        builder.Property(p => p.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(p => p.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(p => p.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(p => !p.DeletedDate.HasValue);
    }
}