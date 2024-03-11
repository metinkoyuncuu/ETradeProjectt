using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class ProductTagConfiguration : IEntityTypeConfiguration<ProductTag>
{
    public void Configure(EntityTypeBuilder<ProductTag> builder)
    {
        builder.ToTable("ProductTags").HasKey(pt => pt.Id);

        builder.Property(pt => pt.Id).HasColumnName("Id").IsRequired();
        builder.Property(pt => pt.ProductId).HasColumnName("ProductId");
        builder.Property(pt => pt.TagId).HasColumnName("TagId");
        builder.Property(pt => pt.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(pt => pt.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(pt => pt.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(pt => !pt.DeletedDate.HasValue);
    }
}