using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class ShopProductConfiguration : IEntityTypeConfiguration<ShopProduct>
{
    public void Configure(EntityTypeBuilder<ShopProduct> builder)
    {
        builder.ToTable("ShopProducts").HasKey(sp => sp.Id);

        builder.Property(sp => sp.Id).HasColumnName("Id").IsRequired();
        builder.Property(sp => sp.ProductId).HasColumnName("ProductId");
        builder.Property(sp => sp.ShopId).HasColumnName("ShopId");
        builder.Property(sp => sp.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(sp => sp.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(sp => sp.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(sp => !sp.DeletedDate.HasValue);
    }
}