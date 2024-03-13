using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCategory>
{
    public void Configure(EntityTypeBuilder<ProductCategory> builder)
    {
        builder.ToTable("ProductCategories").HasKey(pc => pc.Id);

        builder.Property(pc => pc.Id).HasColumnName("Id").IsRequired();
        builder.Property(pc => pc.ProductId).HasColumnName("ProductId");
        builder.Property(pc => pc.CategoryId).HasColumnName("CategoryId");
        builder.Property(pc => pc.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(pc => pc.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(pc => pc.DeletedDate).HasColumnName("DeletedDate");

        builder.HasOne(ca => ca.Product)
         .WithMany()
         .HasForeignKey(ca => ca.ProductId)
         .OnDelete(DeleteBehavior.Restrict);

        builder.HasQueryFilter(pc => !pc.DeletedDate.HasValue);
    }
}