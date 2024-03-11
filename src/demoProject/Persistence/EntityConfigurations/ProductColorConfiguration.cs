using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class ProductColorConfiguration : IEntityTypeConfiguration<ProductColor>
{
    public void Configure(EntityTypeBuilder<ProductColor> builder)
    {
        builder.ToTable("ProductColors").HasKey(pc => pc.Id);

        builder.Property(pc => pc.Id).HasColumnName("Id").IsRequired();
        builder.Property(pc => pc.ProductId).HasColumnName("ProductId");
        builder.Property(pc => pc.ColorId).HasColumnName("ColorId");
        builder.Property(pc => pc.QuantityInStock).HasColumnName("QuantityInStock");
        builder.Property(pc => pc.ImageId).HasColumnName("ImageId");
        builder.Property(pc => pc.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(pc => pc.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(pc => pc.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(pc => !pc.DeletedDate.HasValue);
    }
}