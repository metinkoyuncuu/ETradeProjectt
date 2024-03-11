using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class ProductVariantConfiguration : IEntityTypeConfiguration<ProductVariant>
{
    public void Configure(EntityTypeBuilder<ProductVariant> builder)
    {
        builder.ToTable("ProductVariants").HasKey(pv => pv.Id);

        builder.Property(pv => pv.Id).HasColumnName("Id").IsRequired();
        builder.Property(pv => pv.ProductId).HasColumnName("ProductId");
        builder.Property(pv => pv.ColorId).HasColumnName("ColorId");
        builder.Property(pv => pv.QuantityInStock).HasColumnName("QuantityInStock");
        builder.Property(pv => pv.SizeId).HasColumnName("SizeId");
        builder.Property(pv => pv.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(pv => pv.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(pv => pv.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(pv => !pv.DeletedDate.HasValue);
    }
}